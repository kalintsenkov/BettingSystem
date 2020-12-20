namespace BettingSystem.Domain.Teams.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;

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

        public IReadOnlyCollection<Player> Players => this.players.ToList();

        public Team UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        public void AddPlayer(Player player) => this.players.Add(player);

        private void Validate(string name)
            => Guard.ForStringLength<InvalidTeamException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
