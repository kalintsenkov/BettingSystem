namespace BettingSystem.Infrastructure.Matches
{
    using Common.Persistence;
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface IMatchesDbContext : IDbContext
    {
        DbSet<MatchData> Matches { get; }

        DbSet<StadiumData> Stadiums { get; }

        DbSet<TeamData> Teams { get; }
    }
}
