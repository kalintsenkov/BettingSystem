namespace BettingSystem.Infrastructure.Teams.Persistence
{
    using Common;
    using Microsoft.EntityFrameworkCore;

    internal class TeamsDbInitializer : IInitializer
    {
        private readonly TeamsDbContext db;

        public TeamsDbInitializer(TeamsDbContext db) => this.db = db;

        public void Initialize() => this.db.Database.Migrate();
    }
}
