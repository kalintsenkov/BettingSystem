namespace BettingSystem.Domain.Teams.Factories
{
    using Models;

    internal class TeamFactory : ITeamFactory
    {
        private string teamName = default!;

        public ITeamFactory WithName(string name)
        {
            this.teamName = name;
            return this;
        }

        public Team Build() => new(this.teamName);
    }
}
