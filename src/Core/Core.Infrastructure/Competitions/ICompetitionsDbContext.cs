namespace BettingSystem.Infrastructure.Competitions
{
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Persistence.Models;

    internal interface ICompetitionsDbContext : IDbContext
    {
        DbSet<LeagueData> Leagues { get; }

        DbSet<TeamData> Teams { get; }
    }
}
