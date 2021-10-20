namespace BettingSystem.Infrastructure.Games.Persistence
{
    using System.Reflection;
    using Common.Events;
    using Common.Persistence;
    using Domain.Common.Models;
    using Domain.Games.Models.Matches;
    using Domain.Games.Models.Teams;
    using Microsoft.EntityFrameworkCore;

    internal class GamesDbContext : MessagesDbContext
    {
        public GamesDbContext(
            DbContextOptions<GamesDbContext> options,
            IEventPublisher eventPublisher)
            : base(options, eventPublisher)
        {
        }

        public DbSet<Match> Matches { get; set; } = default!;

        public DbSet<Stadium> Stadiums { get; set; } = default!;

        public DbSet<Team> Teams { get; set; } = default!;

        public DbSet<Image> Images { get; set; } = default!;

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
