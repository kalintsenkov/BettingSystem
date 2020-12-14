namespace BettingSystem.Infrastructure.Betting
{
    using Common.Persistence;
    using Common.Persistence.Models;
    using Domain.Betting.Models.Matches;
    using Microsoft.EntityFrameworkCore;

    internal interface IBettingDbContext : IDbContext
    {
        DbSet<BetData> Bets { get; }

        DbSet<MatchData> Matches { get; }

        DbSet<Stadium> Stadiums { get; }

        DbSet<GamblerData> Gamblers { get; }

        DbSet<TeamData> Teams { get; }
    }
}
