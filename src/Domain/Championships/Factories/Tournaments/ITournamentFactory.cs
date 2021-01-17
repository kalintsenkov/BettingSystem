namespace BettingSystem.Domain.Championships.Factories.Tournaments
{
    using Common;
    using Models.Tournaments;

    public interface ITournamentFactory : IFactory<Tournament>
    {
        ITournamentFactory WithName(string name);

        Tournament Build(string name);
    }
}
