namespace BettingSystem.Infrastructure.Persistence
{
    using System.Reflection;
    using Competitions;
    using Domain.Teams.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Teams;

    internal class BettingDbContext : DbContext,
        ITeamsDbContext,
        ICompetitionsDbContext
    {
        public BettingDbContext(DbContextOptions<BettingDbContext> options)
            : base(options)
        {
        }

        public DbSet<TeamData> Teams { get; set; } = default!;

        public DbSet<Player> Players { get; set; } = default!;

        public DbSet<LeagueData> Leagues { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
