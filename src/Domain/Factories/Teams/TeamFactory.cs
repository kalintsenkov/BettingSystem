namespace BettingSystem.Domain.Factories.Teams
{
    using Models.Teams;

    public class TeamFactory : ITeamFactory
    {
        private string teamName = default!;

        public ITeamFactory WithName(string name)
        {
            this.teamName = name;
            return this;
        }

        public Team Build() => new Team(this.teamName);

        public Team Build(string name)
            => this
                .WithName(name)
                .Build();
    }
}
