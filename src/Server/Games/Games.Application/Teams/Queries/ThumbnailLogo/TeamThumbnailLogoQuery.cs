namespace BettingSystem.Application.Games.Teams.Queries.ThumbnailLogo
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class TeamThumbnailLogoQuery : IRequest<Stream>
    {
        public int Id { get; set; }

        public class TeamThumbnailLogoQueryHandler : IRequestHandler<TeamThumbnailLogoQuery, Stream>
        {
            private readonly ITeamQueryRepository teamRepository;

            public TeamThumbnailLogoQueryHandler(ITeamQueryRepository teamRepository)
                => this.teamRepository = teamRepository;

            public async Task<Stream> Handle(
                TeamThumbnailLogoQuery request,
                CancellationToken cancellationToken)
                => await this.teamRepository.GetThumbnailLogo(
                    request.Id,
                    cancellationToken);
        }
    }
}
