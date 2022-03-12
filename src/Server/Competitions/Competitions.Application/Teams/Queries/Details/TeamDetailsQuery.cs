namespace BettingSystem.Application.Competitions.Teams.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class TeamDetailsQuery : IRequest<TeamDetailsResponseModel?>
{
    public int Id { get; set; }

    public class TeamDetailsQueryHandler : IRequestHandler<TeamDetailsQuery, TeamDetailsResponseModel?>
    {
        private readonly ITeamQueryRepository teamRepository;

        public TeamDetailsQueryHandler(ITeamQueryRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task<TeamDetailsResponseModel?> Handle(
            TeamDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.teamRepository.GetDetails(
                request.Id,
                cancellationToken);
    }
}