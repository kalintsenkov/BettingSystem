namespace BettingSystem.Infrastructure.Competitions
{
    using Common.Persistence;
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface ICompetitionsDbContext : IDbContext
    {
        DbSet<LeagueData> Leagues { get; }

        DbSet<TeamData> Teams { get; }
    }
}
