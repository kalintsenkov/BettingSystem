namespace BettingSystem.Domain.Matches.Factories.Teams
{
    using Common;
    using Models.Teams;

    public interface ITeamFactory : IFactory<Team>
    {
        ITeamFactory WithName(string name);

        Team Build(string name);
    }
}