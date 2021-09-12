namespace BettingSystem.Application.Teams.Commands.Common
{
    using Application.Common;
    using Application.Common.Images;

    public abstract class TeamCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;

        public ImageRequestModel Image { get; set; } = default!;
    }
}
