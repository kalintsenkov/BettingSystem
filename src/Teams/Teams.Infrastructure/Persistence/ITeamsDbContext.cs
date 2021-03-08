namespace BettingSystem.Infrastructure.Teams.Persistence
{
    using Common.Persistence;
    using Domain.Teams.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface ITeamsDbContext : IDbContext
    {
        DbSet<Team> Teams { get; }

        DbSet<Player> Players { get; }
    }
}
