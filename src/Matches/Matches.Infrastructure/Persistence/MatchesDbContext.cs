namespace BettingSystem.Infrastructure.Matches.Persistence
{
    using System.Reflection;
    using BettingSystem.Domain.Matches.Models;
    using Microsoft.EntityFrameworkCore;

    internal class MatchesDbContext : DbContext, IMatchesDbContext
    {
        public MatchesDbContext(DbContextOptions<MatchesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; } = default!;

        public DbSet<Stadium> Stadiums { get; set; } = default!;

        public DbSet<Team> Teams { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
