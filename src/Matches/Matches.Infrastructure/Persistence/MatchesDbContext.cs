namespace BettingSystem.Infrastructure.Matches.Persistence
{
    using System.Reflection;
    using Common.Events;
    using Common.Persistence;
    using Domain.Matches.Models;
    using Microsoft.EntityFrameworkCore;

    internal class MatchesDbContext : MessageDbContext, IMatchesDbContext
    {
        public MatchesDbContext(
            DbContextOptions<MatchesDbContext> options,
            IEventPublisher eventPublisher)
            : base(options, eventPublisher)
        {
        }

        public DbSet<Match> Matches { get; set; } = default!;

        public DbSet<Stadium> Stadiums { get; set; } = default!;

        public DbSet<Team> Teams { get; set; } = default!;

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly(); 
    }
}
