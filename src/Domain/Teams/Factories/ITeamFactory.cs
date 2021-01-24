namespace BettingSystem.Domain.Teams.Factories
{
    using Common;
    using Models;

    public interface ITeamFactory : IFactory<Team>
    {
        ITeamFactory WithName(string name);

        ITeamFactory InLeague(int leagueId);
    }
}