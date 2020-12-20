namespace BettingSystem.Infrastructure.Common.Persistence
{
    using System.Reflection;
    using Betting;
    using Domain.Betting.Models.Matches;
    using Domain.Teams.Models;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Teams;

    internal class BettingDbContext : IdentityDbContext<User>,
        IBettingDbContext,
        ITeamsDbContext
    {
        public BettingDbContext(DbContextOptions<BettingDbContext> options)
            : base(options)
        {
        }

        public DbSet<BetData> Bets { get; set; } = default!;

        public DbSet<MatchData> Matches { get; set; } = default!;

        public DbSet<Stadium> Stadiums { get; set; } = default!;

        public DbSet<GamblerData> Gamblers { get; set; } = default!;

        public DbSet<TeamData> Teams { get; set; } = default!;

        public DbSet<Player> Players { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
