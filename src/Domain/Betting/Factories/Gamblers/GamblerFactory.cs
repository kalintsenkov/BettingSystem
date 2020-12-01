namespace BettingSystem.Domain.Betting.Factories.Gamblers
{
    using Models.Gamblers;

    internal class GamblerFactory : IGamblerFactory
    {
        private string gamblerName = default!;

        public IGamblerFactory WithName(string name)
        {
            this.gamblerName = name;
            return this;
        }

        public Gambler Build() => new Gambler(this.gamblerName);

        public Gambler Build(string name)
            => this
                .WithName(name)
                .Build();
    }
}
