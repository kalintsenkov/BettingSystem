namespace BettingSystem.Infrastructure.Persistence
{
    using System.Reflection;
    using Domain.Models.Bets;
    using Domain.Models.Gamblers;
    using Domain.Models.Matches;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    internal class BettingDbContext : IdentityDbContext<User>
    {
        public BettingDbContext(DbContextOptions<BettingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; } = default!;

        public DbSet<Gambler> Gamblers { get; set; } = default!;

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
