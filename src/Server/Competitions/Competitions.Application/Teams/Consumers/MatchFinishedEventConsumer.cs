﻿namespace BettingSystem.Application.Competitions.Teams.Consumers
{
    using System.Threading.Tasks;
    using Domain.Common.Events.Matches;
    using Domain.Competitions.Repositories;
    using MassTransit;

    public class MatchFinishedEventConsumer : IConsumer<MatchFinishedEvent>
    {
        private readonly ITeamDomainRepository teamRepository;

        public MatchFinishedEventConsumer(ITeamDomainRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task Consume(ConsumeContext<MatchFinishedEvent> context)
            => await this.teamRepository.GivePoints(
                context.Message.HomeTeamId,
                context.Message.AwayTeamId,
                context.Message.HomeScore,
                context.Message.AwayScore);
    }
}
