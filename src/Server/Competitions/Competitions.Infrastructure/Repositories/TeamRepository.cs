namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Teams;
    using Application.Competitions.Teams.Queries.Details;
    using AutoMapper;
    using Common.Repositories;
    using Domain.Competitions.Models.Teams;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class TeamRepository : DataRepository<CompetitionsDbContext, Team>,
        ITeamDomainRepository,
        ITeamQueryRepository
    {
        private readonly IMapper mapper;

        public TeamRepository(CompetitionsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Team?> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<TeamDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TeamDetailsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(t => t.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
