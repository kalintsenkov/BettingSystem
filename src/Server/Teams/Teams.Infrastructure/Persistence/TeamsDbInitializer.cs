namespace BettingSystem.Infrastructure.Teams.Persistence;

using System.Collections.Generic;
using Common.Persistence;
using Domain.Common;

internal class TeamsDbInitializer : DbInitializer
{
    public TeamsDbInitializer(
        TeamsDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : base(db, initialDataProviders)
    {
    }
}