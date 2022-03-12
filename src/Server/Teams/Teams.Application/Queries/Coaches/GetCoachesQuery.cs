namespace BettingSystem.Application.Teams.Queries.Coaches;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetCoachesQuery : IRequest<IEnumerable<GetCoachesResponseModel>>
{
    public class GetCoachesQueryHandler : IRequestHandler<
        GetCoachesQuery,
        IEnumerable<GetCoachesResponseModel>>
    {
        private readonly ITeamQueryRepository teamRepository;

        public GetCoachesQueryHandler(ITeamQueryRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task<IEnumerable<GetCoachesResponseModel>> Handle(
            GetCoachesQuery request,
            CancellationToken cancellationToken)
            => await this.teamRepository.GetCoachesListing(cancellationToken);
    }
}