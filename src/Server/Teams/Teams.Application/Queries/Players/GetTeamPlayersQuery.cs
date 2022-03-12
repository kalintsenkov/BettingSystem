namespace BettingSystem.Application.Teams.Queries.Players;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetTeamPlayersQuery : IRequest<IEnumerable<GetTeamPlayersResponseModel>>
{
    public int Id { get; set; }

    public class GetTeamPlayersQueryHandler : IRequestHandler<
        GetTeamPlayersQuery,
        IEnumerable<GetTeamPlayersResponseModel>>
    {
        private readonly ITeamQueryRepository teamRepository;

        public GetTeamPlayersQueryHandler(ITeamQueryRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task<IEnumerable<GetTeamPlayersResponseModel>> Handle(
            GetTeamPlayersQuery request,
            CancellationToken cancellationToken)
            => await this.teamRepository.GetTeamPlayersListing(
                request.Id,
                cancellationToken);
    }
}