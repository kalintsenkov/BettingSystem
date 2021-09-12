namespace BettingSystem.Domain.Teams.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Events.Teams;
    using Common.Models;
    using Common.Models.Images;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;

    public class Team : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Player> players;

        internal Team(string name, Image image)
        {
            this.Validate(name);

            this.Name = name;
            this.Image = image;

            this.players = new HashSet<Player>();

            this.RaiseEvent(new TeamCreatedEvent(
                this.Name,
                this.Image.Original,
                this.Image.Thumbnail));
        }

        private Team(string name)
        {
            this.Name = name;

            this.Image = default!;

            this.players = new HashSet<Player>();
        }

        public string Name { get; private set; }

        public Image Image { get; private set; }

        public IReadOnlyCollection<Player> Players => this.players.ToList().AsReadOnly();

        public Team UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            this.RaiseEvent(new TeamUpdatedEvent(
                this.Id,
                this.Name));

            return this;
        }

        public void AddPlayer(string name, Position position)
            => this.players.Add(new Player(name, position));

        private void Validate(string name)
            => Guard.ForStringLength<InvalidTeamException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
