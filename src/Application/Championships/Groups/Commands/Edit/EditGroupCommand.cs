namespace BettingSystem.Application.Championships.Groups.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Exceptions;
    using Common;
    using Domain.Championships.Repositories;
    using MediatR;

    public class EditGroupCommand : GroupCommand<EditGroupCommand>, IRequest<Result>
    {
        public class EditGroupCommandHandler : IRequestHandler<EditGroupCommand, Result>
        {
            private readonly IGroupDomainRepository groupRepository;
            private readonly ITournamentDomainRepository tournamentRepository;

            public EditGroupCommandHandler(
                IGroupDomainRepository groupRepository,
                ITournamentDomainRepository tournamentRepository)
            {
                this.groupRepository = groupRepository;
                this.tournamentRepository = tournamentRepository;
            }

            public async Task<Result> Handle(
                EditGroupCommand request,
                CancellationToken cancellationToken)
            {
                var group = await this.groupRepository.Find(
                    request.Id,
                    cancellationToken);

                if (group == null)
                {
                    throw new NotFoundException(nameof(group), request.Id);
                }

                var tournament = await this.tournamentRepository.Find(
                    request.TournamentId,
                    cancellationToken);

                if (tournament == null)
                {
                    throw new NotFoundException(nameof(tournament), request.TournamentId);
                }

                group
                    .UpdateName(request.Name)
                    .UpdateTournament(tournament);

                await this.groupRepository.Save(group, cancellationToken);

                return Result.Success;
            }
        }
    }
}
