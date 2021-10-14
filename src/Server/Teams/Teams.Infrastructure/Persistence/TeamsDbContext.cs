namespace BettingSystem.Infrastructure.Teams.Persistence
{
    using System.Reflection;
    using Common.Events;
    using Common.Persistence;
    using Domain.Teams.Models;
    using Microsoft.EntityFrameworkCore;

    internal class TeamsDbContext : MessagesDbContext
    {
        public TeamsDbContext(
            DbContextOptions<TeamsDbContext> options,
            IEventPublisher eventPublisher)
            : base(options, eventPublisher)
        {
        }

        public DbSet<Team> Teams { get; set; } = default!;

        public DbSet<Player> Players { get; set; } = default!;

        public DbSet<Coach> Coaches { get; set; } = default!;

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
