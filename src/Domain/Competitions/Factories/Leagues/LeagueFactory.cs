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

        public League Build(string name) => this.WithName(this.leagueName).Build();

        public League Build() => new League(this.leagueName);
    }
}
