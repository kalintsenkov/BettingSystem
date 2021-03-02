namespace BettingSystem.Infrastructure.Teams
{
    using Common.Persistence;
    using Domain.Teams.Models;
    using Microsoft.EntityFrameworkCore;
    using Persistence.Models;

    internal interface ITeamsDbContext : IDbContext
    {
        DbSet<TeamData> Teams { get; }

        DbSet<Player> Players { get; }
    }
}
