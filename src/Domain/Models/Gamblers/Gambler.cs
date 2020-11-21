namespace BettingSystem.Domain.Models.Gamblers
{
    using System.Collections.Generic;
    using System.Linq;
    using Bets;
    using Common;
    using Exceptions;

    using static ModelConstants.Common;

    public class Gambler : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Bet> bets;

        internal Gambler(string name)
        {
            this.Validate(name);

            this.Name = name;

            this.bets = new HashSet<Bet>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<Bet> Bets => this.bets.ToList().AsReadOnly();

        public Gambler UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        public void AddBet(Bet bet) => this.bets.Add(bet);

        private void Validate(string name)
            => Guard.ForStringLength<InvalidGamblerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
