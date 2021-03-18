namespace BettingSystem.Domain.Competitions.Factories
{
    using Common;
    using Models.Leagues;

    public interface ILeagueFactory : IFactory<League>
    {
        ILeagueFactory WithName(string name);
    }
}