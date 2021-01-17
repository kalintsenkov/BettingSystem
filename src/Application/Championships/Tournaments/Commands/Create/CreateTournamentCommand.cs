namespace BettingSystem.Application.Championships.Tournaments.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Championships.Factories.Tournaments;
    using Domain.Championships.Repositories;
    using MediatR;

    public class CreateTournamentCommand : IRequest<CreateTournamentResponseModel>
    {
        public string Name { get; set; } = default!;

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

                await this.tournamentRepository.Save(tournament, cancellationToken);

                return new CreateTournamentResponseModel(tournament.Id);
            }
        }
    }
}
