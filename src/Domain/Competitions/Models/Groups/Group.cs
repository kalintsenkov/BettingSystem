namespace BettingSystem.Domain.Competitions.Models.Groups
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;
    using Exceptions;
    using Matches;
    using Tournaments;

    using static Common.Models.ModelConstants.Common;

    public class Group : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Match> matches;

        internal Group(string name, Tournament tournament)
        {
            this.Validate(name);

            this.Name = name;
            this.Tournament = tournament;

            this.matches = new HashSet<Match>();
        }

        private Group(string name)
        {
            this.Name = name;

            this.Tournament = default!;

            this.matches = new HashSet<Match>();
        }

        public string Name { get; private set; }

        public Tournament Tournament { get; private set; }

        public IReadOnlyCollection<Match> Matches => this.matches.ToList();

        public Group UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        public Group UpdateTournament(Tournament tournament)
        {
            this.Tournament = tournament;

            return this;
        }

        public void AddMatch(Match match) => this.matches.Add(match);

        public void Validate(string name)
            => Guard.ForStringLength<InvalidGroupException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
