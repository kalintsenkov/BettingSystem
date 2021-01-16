namespace BettingSystem.Domain.Tournaments.Factories
{
    using Common;
    using Models.Tournaments;

    public interface ITournamentFactory : IFactory<Tournament>
    {
        ITournamentFactory WithName(string name);

        Tournament Build(string name);
    }
}
