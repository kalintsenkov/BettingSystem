namespace BettingSystem.Infrastructure.Teams.Persistence
{
    using System.Reflection;
    using Domain.Teams.Models;
    using Microsoft.EntityFrameworkCore;

    internal class TeamsDbContext : DbContext
    {
        public TeamsDbContext(DbContextOptions<TeamsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; } = default!;

        public DbSet<Player> Players { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
