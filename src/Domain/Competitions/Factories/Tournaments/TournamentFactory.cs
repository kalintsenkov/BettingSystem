namespace BettingSystem.Domain.Competitions.Factories.Tournaments
{
    using Models.Tournaments;

    internal class TournamentFactory : ITournamentFactory
    {
        private string tournamentName = default!;

        public ITournamentFactory WithName(string name)
        {
            this.tournamentName = name;
            return this;
        }

        public Tournament Build(string name) => this.WithName(name).Build();

        public Tournament Build() => new Tournament(this.tournamentName);
    }
}
