namespace BettingSystem.Application.Competitions.Groups.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Exceptions;
    using Common;
    using Domain.Competitions.Factories.Groups;
    using Domain.Competitions.Repositories;
    using MediatR;

    public class CreateGroupCommand : GroupCommand<CreateGroupCommand>, IRequest<CreateGroupResponseModel>
    {
        public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, CreateGroupResponseModel>
        {
            private readonly IGroupFactory groupFactory;
            private readonly IGroupDomainRepository groupRepository;
            private readonly ITournamentDomainRepository tournamentRepository;

            public CreateGroupCommandHandler(
                IGroupFactory groupFactory,
                IGroupDomainRepository groupRepository,
                ITournamentDomainRepository tournamentRepository)
            {
                this.groupFactory = groupFactory;
                this.groupRepository = groupRepository;
                this.tournamentRepository = tournamentRepository;
            }

            public async Task<CreateGroupResponseModel> Handle(
                CreateGroupCommand request,
                CancellationToken cancellationToken)
            {
                var tournament = await this.tournamentRepository.Find(
                    request.TournamentId,
                    cancellationToken);

                if (tournament == null)
                {
                    throw new NotFoundException(
                        nameof(tournament),
                        request.TournamentId);
                }

                var group = this.groupFactory
                    .WithName(request.Name)
                    .WithTournament(tournament)
                    .Build();

                await this.groupRepository.Save(group, cancellationToken);

                return new CreateGroupResponseModel(group.Id);
            }
        }
    }
}
