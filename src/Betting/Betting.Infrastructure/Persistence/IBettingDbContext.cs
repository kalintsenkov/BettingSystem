namespace BettingSystem.Infrastructure.Betting.Persistence
{
    using Common.Persistence;
    using Domain.Betting.Models.Bets;
    using Domain.Betting.Models.Gamblers;
    using Domain.Betting.Models.Matches;
    using Microsoft.EntityFrameworkCore;

    internal interface IBettingDbContext : IDbContext
    {
        DbSet<Bet> Bets { get; }

        DbSet<Match> Matches { get; }

        DbSet<Gambler> Gamblers { get; }

        DbSet<Team> Teams { get; }
    }
}
