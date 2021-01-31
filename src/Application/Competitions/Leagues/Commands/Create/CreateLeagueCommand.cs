namespace BettingSystem.Application.Competitions.Leagues.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Domain.Competitions.Factories.Leagues;
    using Domain.Competitions.Repositories;
    using MediatR;

    public class CreateLeagueCommand : LeagueCommand<CreateLeagueCommand>, IRequest<CreateLeagueResponseModel>
    {
        public class CreateLeagueCommandHandler : IRequestHandler<CreateLeagueCommand, CreateLeagueResponseModel>
        {
            private readonly ILeagueFactory leagueFactory;
            private readonly ILeagueDomainRepository leagueRepository;

            public CreateLeagueCommandHandler(
                ILeagueFactory leagueFactory,
                ILeagueDomainRepository leagueRepository)
            {
                this.leagueFactory = leagueFactory;
                this.leagueRepository = leagueRepository;
            }

            public async Task<CreateLeagueResponseModel> Handle(
                CreateLeagueCommand request,
                CancellationToken cancellationToken)
            {
                var league = this.leagueFactory
                    .WithName(request.Name)
                    .Build();

                league = await this.leagueRepository.Save(league, cancellationToken);

                return new CreateLeagueResponseModel(league.Id);
            }
        }
    }
}
