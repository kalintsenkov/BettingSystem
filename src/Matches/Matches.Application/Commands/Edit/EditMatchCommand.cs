namespace BettingSystem.Application.Matches.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Common;
    using Domain.Matches.Repositories;
    using MediatR;

    public class EditMatchCommand : MatchCommand<EditMatchCommand>, IRequest<Result>
    {
        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

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

                var homeTeam = await this.matchRepository.GetTeam(
                    request.HomeTeam,
                    cancellationToken);

                var awayTeam = await this.matchRepository.GetTeam(
                    request.AwayTeam,
                    cancellationToken);

                var stadium = await this.matchRepository.GetStadium(
                    request.StadiumName,
                    cancellationToken);

                match
                    .UpdateStartDate(request.StartDate)
                    .UpdateHomeTeam(homeTeam)
                    .UpdateAwayTeam(awayTeam)
                    .UpdateStadium(stadium)
                    .UpdateStatistics(request.HomeTeamScore, request.AwayTeamScore);

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
