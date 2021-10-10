namespace BettingSystem.Application.Competitions.Leagues.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Exceptions;
    using Common;
    using Domain.Competitions.Repositories;
    using MediatR;

    public class EditLeagueCommand : LeagueCommand<EditLeagueCommand>, IRequest<Result>
    {
        public class EditLeagueCommandHandler : IRequestHandler<EditLeagueCommand, Result>
        {
            private readonly ILeagueDomainRepository leagueRepository;

            public EditLeagueCommandHandler(ILeagueDomainRepository leagueRepository)
                => this.leagueRepository = leagueRepository;

            public async Task<Result> Handle(
                EditLeagueCommand request,
                CancellationToken cancellationToken)
            {
                var league = await this.leagueRepository.Find(
                    request.Id,
                    cancellationToken);

                if (league == null)
                {
                    throw new NotFoundException(nameof(league), request.Id);
                }

                var country = await this.leagueRepository.GetCountry(
                    request.Country,
                    cancellationToken);

                if (country == null)
                {
                    throw new NotFoundException(nameof(country), request.Country);
                }

                league
                    .UpdateName(request.Name)
                    .UpdateCountry(country);

                await this.leagueRepository.Save(league, cancellationToken);

                return Result.Success;
            }
        }
    }
}
