﻿namespace BettingSystem.Application.Teams.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Common;
    using Domain.Teams.Repositories;
    using MediatR;

    public class EditTeamCommand : TeamCommand<EditTeamCommand>, IRequest<Result>
    {
        public class EditTeamCommandHandler : IRequestHandler<EditTeamCommand, Result>
        {
            private readonly ITeamDomainRepository teamRepository;

            public EditTeamCommandHandler(ITeamDomainRepository teamRepository)
                => this.teamRepository = teamRepository;

            public async Task<Result> Handle(
                EditTeamCommand request,
                CancellationToken cancellationToken)
            {
                var team = await this.teamRepository.Find(
                    request.Id,
                    cancellationToken);

                team.UpdateName(request.Name);

                await this.teamRepository.Save(team, cancellationToken);

                return Result.Success;
            }
        }
    }
}
