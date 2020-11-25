namespace BettingSystem.Application.Features.Matches.Commands.Edit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class EditMatchCommand : EntityCommand<int, EditMatchCommand>, IRequest<Result>
    {
        public DateTime? StartDate { get; set; }

        public string? HomeTeam { get; set; }

        public string? AwayTeam { get; set; }

        public string? Stadium { get; set; }

        public int? HomeTeamScore { get; set; }

        public int? AwayTeamScore { get; set; }

        public class EditMatchCommandHandler : IRequestHandler<EditMatchCommand, Result>
        {
            private readonly IMatchRepository matchRepository;

            public EditMatchCommandHandler(IMatchRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                EditMatchCommand request,
                CancellationToken cancellationToken)
            {
                var match = await this.matchRepository.Find(
                    request.Id,
                    cancellationToken);

                if (request.HomeTeam != null)
                {
                    var homeTeam = await this.matchRepository.GetHomeTeam(
                        request.HomeTeam,
                        cancellationToken);

                    match.UpdateHomeTeam(homeTeam);
                }

                if (request.AwayTeam != null)
                {
                    var awayTeam = await this.matchRepository.GetAwayTeam(
                        request.AwayTeam,
                        cancellationToken);

                    match.UpdateAwayTeam(awayTeam);
                }

                if (request.Stadium != null)
                {
                    var stadium = await this.matchRepository.GetStadium(
                        request.Stadium,
                        cancellationToken);

                    match.UpdateStadium(stadium);
                }

                match
                    .UpdateStartDate(request.StartDate ?? match.StartDate)
                    .UpdateStatistics(request.HomeTeamScore, request.AwayTeamScore);

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
