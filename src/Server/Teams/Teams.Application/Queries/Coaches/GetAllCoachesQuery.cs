namespace BettingSystem.Application.Teams.Queries.Coaches
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetAllCoachesQuery : IRequest<IEnumerable<GetAllCoachesResponseModel>>
    {
        public class GetAllCoachesQueryHandler : IRequestHandler<
            GetAllCoachesQuery,
            IEnumerable<GetAllCoachesResponseModel>>
        {
            private readonly ITeamQueryRepository teamRepository;

            public GetAllCoachesQueryHandler(ITeamQueryRepository teamRepository)
                => this.teamRepository = teamRepository;

            public async Task<IEnumerable<GetAllCoachesResponseModel>> Handle(
                GetAllCoachesQuery request,
                CancellationToken cancellationToken)
                => await this.teamRepository.GetCoaches(cancellationToken);
        }
    }
}
