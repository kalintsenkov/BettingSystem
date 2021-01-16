namespace BettingSystem.Infrastructure.Common.Persistence
{
    using System.Reflection;
    using Betting;
    using Domain.Teams.Models;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Teams;
    using Tournaments;

    internal class BettingDbContext : IdentityDbContext<User>,
        IBettingDbContext,
        ITeamsDbContext,
        ITournamentsDbContext
    {
        public BettingDbContext(DbContextOptions<BettingDbContext> options)
            : base(options)
        {
        }

        public DbSet<BetData> Bets { get; set; } = default!;

        public DbSet<MatchData> Matches { get; set; } = default!;

        public DbSet<StadiumData> Stadiums { get; set; } = default!;

        public DbSet<GamblerData> Gamblers { get; set; } = default!;

        public DbSet<TeamData> Teams { get; set; } = default!;

        public DbSet<Player> Players { get; set; } = default!;

        public DbSet<TournamentData> Tournaments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
