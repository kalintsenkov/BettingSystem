namespace BettingSystem.Domain.Teams.Factories
{
    using Models;

    internal class TeamFactory : ITeamFactory
    {
        private const int DefaultTeamPoints = 0;

        private string teamName = default!;
        private int teamLeagueId = default!;

        public ITeamFactory WithName(string name)
        {
            this.teamName = name;
            return this;
        }

        public ITeamFactory InLeague(int leagueId)
        {
            this.teamLeagueId = leagueId;
            return this;
        }

        public Team Build() => new Team(
            this.teamName,
            this.teamLeagueId,
            DefaultTeamPoints);
    }
}
