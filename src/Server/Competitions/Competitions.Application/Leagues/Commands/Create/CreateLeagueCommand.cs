namespace BettingSystem.Application.Competitions.Leagues.Commands.Create;

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
            var country = await this.leagueRepository.GetCountry(
                request.Country,
                cancellationToken);

            var factory = this.leagueFactory.WithName(request.Name);

            factory = country != null
                ? factory.WithCountry(country)
                : factory.WithCountry(request.Country);

            var league = factory.Build();

            await this.leagueRepository.Save(league, cancellationToken);

            return new CreateLeagueResponseModel(league.Id);
        }
    }
}