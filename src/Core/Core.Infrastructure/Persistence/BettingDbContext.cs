namespace BettingSystem.Infrastructure.Persistence
{
    using System.Reflection;
    using Competitions;
    using Microsoft.EntityFrameworkCore;
    using Models;

    internal class BettingDbContext : DbContext, ICompetitionsDbContext
    {
        public BettingDbContext(DbContextOptions<BettingDbContext> options)
            : base(options)
        {
        }

        public DbSet<TeamData> Teams { get; set; } = default!;

        public DbSet<LeagueData> Leagues { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
