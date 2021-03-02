namespace BettingSystem.Infrastructure.Teams
{
    using Common.Persistence;
    using Common.Persistence.Models;
    using Domain.Teams.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface ITeamsDbContext : IDbContext
    {
        DbSet<TeamData> Teams { get; }

        DbSet<Player> Players { get; }
    }
}
