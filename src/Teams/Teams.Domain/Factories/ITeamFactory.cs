namespace BettingSystem.Domain.Teams.Factories
{
    using Common;
    using Models;

    public interface ITeamFactory : IFactory<Team>
    {
        ITeamFactory WithName(string name);

        Team Build(string name);
    }
}