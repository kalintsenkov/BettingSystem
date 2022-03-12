namespace BettingSystem.Infrastructure.Games.Persistence;

using System.Collections.Generic;
using Common.Persistence;
using Domain.Common;

internal class GamesDbInitializer : DbInitializer
{
    public GamesDbInitializer(
        GamesDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : base(db, initialDataProviders)
    {
    }
}