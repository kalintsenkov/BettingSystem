namespace BettingSystem.Application.Teams.Queries.All
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetAllTeamsQuery : IRequest<IEnumerable<GetAllTeamsResponseModel>>
    {
        public class GetAllTeamsQueryHandler : IRequestHandler<
            GetAllTeamsQuery,
            IEnumerable<GetAllTeamsResponseModel>>
        {
            private readonly ITeamQueryRepository teamRepository;

            public GetAllTeamsQueryHandler(ITeamQueryRepository teamRepository)
                => this.teamRepository = teamRepository;

            public async Task<IEnumerable<GetAllTeamsResponseModel>> Handle(
                GetAllTeamsQuery request,
                CancellationToken cancellationToken)
                => await this.teamRepository.GetTeamsListing(cancellationToken);
        }
    }
}
