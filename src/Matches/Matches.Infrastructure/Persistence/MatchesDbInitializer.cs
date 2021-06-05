namespace BettingSystem.Infrastructure.Matches.Persistence
{
    using System.Collections.Generic;
    using Common.Persistence;
    using Domain.Common;

    internal class MatchesDbInitializer : DbInitializer
    {
        public MatchesDbInitializer(
            MatchesDbContext db,
            IEnumerable<IInitialData> initialDataProviders)
            : base(db, initialDataProviders)
        {
        }
    }
}
