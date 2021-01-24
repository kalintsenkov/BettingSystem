namespace BettingSystem.Infrastructure.Competitions
{
    using Common.Persistence;
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface ICompetitionsDbContext : IDbContext
    {
        DbSet<LeagueData> Leagues { get; }

        DbSet<MatchData> Matches { get; }

        DbSet<StadiumData> Stadiums { get; }

        DbSet<TeamData> Teams { get; }
    }
}
