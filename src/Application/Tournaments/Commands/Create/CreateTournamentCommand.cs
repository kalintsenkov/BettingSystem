namespace BettingSystem.Application.Tournaments.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Exceptions;
    using Domain.Tournaments.Factories;
    using Domain.Tournaments.Repositories;
    using MediatR;

    public class CreateTournamentCommand : IRequest<CreateTournamentResponseModel>
    {
        public string Name { get; set; } = default!;

        public int MatchId { get; set; }

        public class CreateTournamentCommandHandler : IRequestHandler<
            CreateTournamentCommand,
            CreateTournamentResponseModel>
        {
            private readonly ITournamentFactory tournamentFactory;
            private readonly ITournamentDomainRepository tournamentRepository;

            public CreateTournamentCommandHandler(
                ITournamentFactory tournamentFactory,
                ITournamentDomainRepository tournamentRepository)
            {
                this.tournamentFactory = tournamentFactory;
                this.tournamentRepository = tournamentRepository;
            }

            public async Task<CreateTournamentResponseModel> Handle(
                CreateTournamentCommand request,
                CancellationToken cancellationToken)
            {
                var tournament = this.tournamentFactory.Build(request.Name);

                var match = await this.tournamentRepository.FindMatch(
                    request.MatchId,
                    cancellationToken);

                if (match == null)
                {
                    throw new NotFoundException(nameof(match), request.MatchId);
                }

                tournament.AddMatch(match);

                await this.tournamentRepository.Save(tournament, cancellationToken);

                return new CreateTournamentResponseModel(tournament.Id);
            }
        }
    }
}
