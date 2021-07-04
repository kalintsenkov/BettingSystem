namespace BettingSystem.Infrastructure.Games.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Games.Teams;
    using Common.Repositories;
    using Domain.Games.Models.Teams;
    using Domain.Games.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class TeamRepository : DataRepository<GamesDbContext, Team>,
        ITeamDomainRepository,
        ITeamQueryRepository
    {
        public TeamRepository(GamesDbContext db)
            : base(db)
        {
        }

        public async Task<Team> Find(
            string team,
            CancellationToken cancellationToken = default)
            => await this
                .AllAsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == team, cancellationToken);

        public async Task<Team> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
