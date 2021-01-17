namespace BettingSystem.Domain.Championships.Factories.Groups
{
    using Common;
    using Models.Groups;
    using Models.Tournaments;

    public interface IGroupFactory : IFactory<Group>
    {
        IGroupFactory WithName(string name);

        IGroupFactory WithTournament(Tournament tournament);
    }
}