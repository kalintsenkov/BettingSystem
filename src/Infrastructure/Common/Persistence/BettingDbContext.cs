namespace BettingSystem.Infrastructure.Common.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Betting;
    using Competitions;
    using Domain.Common.Models;
    using Domain.Teams.Models;
    using Events;
    using Identity;
    using Matches;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Teams;

    internal class BettingDbContext : IdentityDbContext<User>,
        IBettingDbContext,
        ITeamsDbContext,
        IMatchesDbContext,
        ICompetitionsDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly Stack<object> savesChangesTracker;

        public BettingDbContext(
            DbContextOptions<BettingDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.savesChangesTracker = new Stack<object>();
        }

        public DbSet<BetData> Bets { get; set; } = default!;

        public DbSet<MatchData> Matches { get; set; } = default!;

        public DbSet<StadiumData> Stadiums { get; set; } = default!;

        public DbSet<GamblerData> Gamblers { get; set; } = default!;

        public DbSet<TeamData> Teams { get; set; } = default!;

        public DbSet<Player> Players { get; set; } = default!;

        public DbSet<LeagueData> Leagues { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
