namespace BettingSystem.Infrastructure.Betting
{
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Persistence.Models;

    internal interface IBettingDbContext : IDbContext
    {
        DbSet<BetData> Bets { get; }

        DbSet<MatchData> Matches { get; }

        DbSet<GamblerData> Gamblers { get; }
    }
}
