namespace BettingSystem.Infrastructure.Competitions.Persistence;

using System.Collections.Generic;
using Common.Persistence;
using Domain.Common;

internal class CompetitionsDbInitializer : DbInitializer
{
    public CompetitionsDbInitializer(
        CompetitionsDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : base(db, initialDataProviders)
    {
    }
}