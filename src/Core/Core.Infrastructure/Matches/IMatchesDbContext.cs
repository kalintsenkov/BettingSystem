namespace BettingSystem.Infrastructure.Matches
{
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Persistence.Models;

    internal interface IMatchesDbContext : IDbContext
    {
        DbSet<MatchData> Matches { get; }

        DbSet<StadiumData> Stadiums { get; }

        DbSet<TeamData> Teams { get; }
    }
}
