namespace BettingSystem.Infrastructure.Competitions.Persistence
{
    using Common.Persistence;
    using Domain.Competitions.Models.Leagues;
    using Microsoft.EntityFrameworkCore;

    internal interface ICompetitionsDbContext : IDbContext
    {
        DbSet<League> Leagues { get; }

        DbSet<Team> Teams { get; }
    }
}
