namespace BettingSystem.Domain.Tournaments.Models.Tournaments
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;
    using Exceptions;
    using Matches;

    using static Common.Models.ModelConstants.Common;

    public class Tournament : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Match> matches;

        internal Tournament(string name)
        {
            this.Validate(name);

            this.Name = name;

            this.matches = new HashSet<Match>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<Match> Matches => this.matches.ToList();

        public Tournament UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        public void AddMatch(Match match) => this.matches.Add(match);

        public void Validate(string name)
            => Guard.ForStringLength<InvalidTournamentException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
