namespace BettingSystem.Application.Teams.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Domain.Teams.Repositories;
using MediatR;

public class DeleteTeamCommand : EntityCommand<int>, IRequest<Result>
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, Result>
    {
        private readonly ITeamDomainRepository teamRepository;

        public DeleteTeamCommandHandler(ITeamDomainRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task<Result> Handle(
            DeleteTeamCommand request,
            CancellationToken cancellationToken)
            => await this.teamRepository.Delete(
                request.Id,
                cancellationToken);
    }
}