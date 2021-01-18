namespace BettingSystem.Infrastructure.Competitions
{
    using Common.Persistence;
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface ITournamentsDbContext : IDbContext
    {
        DbSet<TournamentData> Tournaments { get; }

        DbSet<GroupData> Groups { get; }

        DbSet<MatchData> Matches { get; }

        DbSet<StadiumData> Stadiums { get; }

        DbSet<TeamData> Teams { get; }
    }
}
