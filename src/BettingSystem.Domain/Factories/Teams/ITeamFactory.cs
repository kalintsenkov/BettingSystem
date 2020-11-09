namespace BettingSystem.Domain.Factories.Teams
{
    using Models.Teams;

    public interface ITeamFactory : IFactory<Team>
    {
        ITeamFactory WithName(string name);

        Team Build(string name);
    }
}
