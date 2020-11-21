namespace BettingSystem.Domain.Factories.Gamblers
{
    using Models.Gamblers;

    public interface IGamblerFactory : IFactory<Gambler>
    {
        IGamblerFactory WithName(string name);

        Gambler Build(string name);
    }
}
