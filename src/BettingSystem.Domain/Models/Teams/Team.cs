namespace BettingSystem.Domain.Models.Teams
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Exceptions;

    using static ModelConstants.Common;

    public class Team : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Player> players;

        internal Team(string name)
        {
            this.Validate(name);

            this.Name = name;

            this.players = new HashSet<Player>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<Player> Players => this.players.ToList().AsReadOnly();

        public void AddPlayer(Player player) => this.players.Add(player);

        public Team UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidTeamException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
