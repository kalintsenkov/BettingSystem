namespace BettingSystem.Infrastructure.Matches.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Matches.Teams;
    using Common.Repositories;
    using Domain.Matches.Models.Teams;
    using Domain.Matches.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class TeamRepository : DataRepository<MatchesDbContext, Team>,
        ITeamDomainRepository,
        ITeamQueryRepository
    {
        public TeamRepository(MatchesDbContext db)
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
