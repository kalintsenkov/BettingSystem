namespace BettingSystem.Domain.Competitions.Models.Tournaments
{
    using Common;
    using Common.Models;
    using Exceptions;
    using static Common.Models.ModelConstants.Common;

    public class Tournament : Entity<int>, IAggregateRoot
    {
        internal Tournament(string name)
        {
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; private set; }

        public Tournament UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        public void Validate(string name)
            => Guard.ForStringLength<InvalidTournamentException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
