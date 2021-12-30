namespace BettingSystem.Application.Games.Teams.Queries.OriginalLogo
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class TeamOriginalLogoQuery : IRequest<Stream>
    {
        public int Id { get; set; }

        public class TeamOriginalLogoQueryHandler : IRequestHandler<TeamOriginalLogoQuery, Stream>
        {
            private readonly ITeamQueryRepository teamRepository;

            public TeamOriginalLogoQueryHandler(ITeamQueryRepository teamRepository)
                => this.teamRepository = teamRepository;

            public async Task<Stream> Handle(
                TeamOriginalLogoQuery request,
                CancellationToken cancellationToken)
                => await this.teamRepository.GetOriginalLogo(
                    request.Id,
                    cancellationToken);
        }
    }
}
