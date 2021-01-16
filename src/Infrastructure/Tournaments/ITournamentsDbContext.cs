namespace BettingSystem.Infrastructure.Tournaments
{
    using Common.Persistence;
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface ITournamentsDbContext : IDbContext
    {
        DbSet<TournamentData> Tournaments { get; }

        DbSet<MatchData> Matches { get; }
    }
}
