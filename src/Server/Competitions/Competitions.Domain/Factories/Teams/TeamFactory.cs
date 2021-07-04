namespace BettingSystem.Domain.Competitions.Factories.Teams
{
    using Models.Teams;

    internal class TeamFactory : ITeamFactory
    {
        private string teamName = default!;

        public ITeamFactory WithName(string name)
        {
            this.teamName = name;
            return this;
        }

        public Team Build() => new(this.teamName, points: 0);

        public Team Build(string name) => this.WithName(name).Build();
    }
}
