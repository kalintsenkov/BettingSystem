namespace BettingSystem.Domain.Competitions.Models.Leagues
{
    using Common;
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;

    public class League : Entity<int>, IAggregateRoot
    {
        internal League(string name)
        {
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; private set; }

        public League UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        public void Validate(string name)
            => Guard.ForStringLength<InvalidLeagueException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
