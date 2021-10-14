namespace BettingSystem.Domain.Competitions.Factories.Leagues
{
    using Exceptions;
    using Models.Leagues;

    internal class LeagueFactory : ILeagueFactory
    {
        private string leagueName = default!;
        private Country leagueCountry = default!;

        private bool isNameSet = false;
        private bool isCountrySet = false;

        public ILeagueFactory WithName(string name)
        {
            this.leagueName = name;
            this.isNameSet = true;

            return this;
        }

        public ILeagueFactory WithCountry(string name)
        {
            var country = new Country(name);

            return this.WithCountry(country);
        }

        public ILeagueFactory WithCountry(Country country)
        {
            this.leagueCountry = country;
            this.isCountrySet = true;

            return this;
        }

        public League Build()
        {
            if (!this.isNameSet || !this.isCountrySet)
            {
                throw new InvalidLeagueException("Name and country must have a value.");
            }

            return new League(this.leagueName, this.leagueCountry);
        }
    }
}
