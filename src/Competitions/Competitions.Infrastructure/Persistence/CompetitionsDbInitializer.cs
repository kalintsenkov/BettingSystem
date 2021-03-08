namespace BettingSystem.Infrastructure.Competitions.Persistence
{
    using Common;
    using Microsoft.EntityFrameworkCore;

    internal class CompetitionsDbInitializer : IInitializer
    {
        private readonly CompetitionsDbContext db;

        public CompetitionsDbInitializer(CompetitionsDbContext db) => this.db = db;

        public void Initialize() => this.db.Database.Migrate();
    }
}
