namespace BettingSystem.Infrastructure.Matches.Persistence
{
    using Common.Persistence;
    using Domain.Matches.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface IMatchesDbContext : IDbContext
    {
        DbSet<Match> Matches { get; }

        DbSet<Stadium> Stadiums { get; }

        DbSet<Team> Teams { get; }
    }
}
