namespace BettingSystem.Application.Betting.Matches.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Common;
    using Domain.Betting.Repositories;
    using MediatR;

    public class EditMatchCommand : MatchCommand<EditMatchCommand>, IRequest<Result>
    {
        public int? HomeTeamScore { get; set; }

        public int? AwayTeamScore { get; set; }

        public class EditMatchCommandHandler : IRequestHandler<EditMatchCommand, Result>
        {
            private readonly IMatchDomainRepository matchRepository;

            public EditMatchCommandHandler(IMatchDomainRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                EditMatchCommand request,
                CancellationToken cancellationToken)
            {
                var match = await this.matchRepository.Find(
                    request.Id,
                    cancellationToken);

                var homeTeam = await this.matchRepository.GetHomeTeam(
                    request.HomeTeam,
                    cancellationToken);

                var awayTeam = await this.matchRepository.GetAwayTeam(
                    request.AwayTeam,
                    cancellationToken);

                var stadium = await this.matchRepository.GetStadium(
                    request.StadiumName,
                    cancellationToken);

                match = homeTeam == null
                    ? match.UpdateHomeTeam(request.HomeTeam)
                    : match.UpdateHomeTeam(homeTeam);

                match = awayTeam == null
                    ? match.UpdateAwayTeam(request.AwayTeam)
                    : match.UpdateAwayTeam(awayTeam);

                match = stadium == null
                    ? match.UpdateStadium(request.StadiumName, request.StadiumImageUrl)
                    : match.UpdateStadium(stadium);

                match
                    .UpdateStartDate(request.StartDate)
                    .UpdateStatistics(request.HomeTeamScore, request.AwayTeamScore);

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
