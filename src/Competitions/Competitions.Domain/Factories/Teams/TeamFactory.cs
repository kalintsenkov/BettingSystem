namespace BettingSystem.Domain.Competitions.Factories.Teams
{
    using Models.Teams;

    internal class TeamFactory : ITeamFactory
    {
        private const int DefaultTeamPoints = 0;

        private string teamName = default!;

        public ITeamFactory WithName(string name)
        {
            this.teamName = name;
            return this;
        }

        public Team Build() => new Team(this.teamName, DefaultTeamPoints);
    }
}
