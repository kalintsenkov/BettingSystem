namespace BettingSystem.Domain.Betting.Factories.Gamblers
{
    using Models.Gamblers;

    internal class GamblerFactory : IGamblerFactory
    {
        private string gamblerName = default!;
        private string gamblerUserId = default!;

        public IGamblerFactory WithName(string name)
        {
            this.gamblerName = name;
            return this;
        }

        public IGamblerFactory FromUser(string userId)
        {
            this.gamblerUserId = userId;
            return this;
        }

        public Gambler Build() => new(this.gamblerName, this.gamblerUserId);
    }
}
