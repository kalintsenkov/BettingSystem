namespace BettingSystem.Infrastructure.Competitions.Persistence
{
    using System.Reflection;
    using Domain.Competitions.Models.Leagues;
    using Domain.Competitions.Models.Teams;
    using Microsoft.EntityFrameworkCore;

    internal class CompetitionsDbContext : DbContext
    {
        public CompetitionsDbContext(DbContextOptions<CompetitionsDbContext> options)
            : base(options)
        {
        }

        public DbSet<League> Leagues { get; set; } = default!;

        public DbSet<Team> Teams { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
