namespace BettingSystem.Application.Teams.Commands.AddPlayer
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Exceptions;
    using Domain.Common.Models;
    using Domain.Teams.Models;
    using Domain.Teams.Repositories;
    using MediatR;

    public class AddPlayerCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public int Position { get; set; }

        public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, Result>
        {
            private readonly ITeamDomainRepository teamRepository;

            public AddPlayerCommandHandler(ITeamDomainRepository teamRepository)
                => this.teamRepository = teamRepository;

            public async Task<Result> Handle(
                AddPlayerCommand request,
                CancellationToken cancellationToken)
            {
                var team = await this.teamRepository.Find(
                    request.Id,
                    cancellationToken);

                if (team == null)
                {
                    throw new NotFoundException(nameof(team), request.Id);
                }

                team.AddPlayer(
                    request.Name,
                    Enumeration.FromValue<Position>(request.Position));

                await this.teamRepository.Save(team, cancellationToken);

                return Result.Success;
            }
        }
    }
}
