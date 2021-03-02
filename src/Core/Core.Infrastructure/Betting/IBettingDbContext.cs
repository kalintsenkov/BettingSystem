namespace BettingSystem.Infrastructure.Betting
{
    using Common.Persistence;
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface IBettingDbContext : IDbContext
    {
        DbSet<BetData> Bets { get; }

        DbSet<MatchData> Matches { get; }

        DbSet<GamblerData> Gamblers { get; }
    }
}
