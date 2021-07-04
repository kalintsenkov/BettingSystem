namespace BettingSystem.Domain.Competitions.Factories.Leagues
{
    using Models.Leagues;

    internal class LeagueFactory : ILeagueFactory
    {
        private string leagueName = default!;

        public ILeagueFactory WithName(string name)
        {
            this.leagueName = name;
            return this;
        }

        public League Build() => new(this.leagueName);

        public League Build(string name) => this.WithName(name).Build();
    }
}
