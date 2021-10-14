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

        internal Team(
            string name,
            Image logo,
            Coach coach)
        {
            this.Validate(name);

            this.Name = name;
            this.Logo = logo;
            this.Coach = coach;

            this.players = new HashSet<Player>();

            this.RaiseEvent(new TeamCreatedEvent(
                this.Name,
                this.Logo.OriginalContent,
                this.Logo.ThumbnailContent));
        }

        private Team(string name)
        {
            this.Name = name;

            this.Logo = default!;
            this.Coach = default!;

            this.players = new HashSet<Player>();
        }

        public string Name { get; private set; }

        public Image Logo { get; private set; }

        public Coach Coach { get; private set; }

        public IReadOnlyCollection<Player> Players => this.players.ToList().AsReadOnly();

        public Team UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            this.RaiseEvent(new TeamNameUpdatedEvent(
                this.Id,
                this.Name));

            return this;
        }

        public Team UpdateLogo(byte[] originalContent, byte[] thumbnailContent)
        {
            this.Logo = new Image(originalContent, thumbnailContent);

            this.RaiseEvent(new TeamLogoUpdatedEvent(
                this.Id,
                this.Name,
                this.Logo.OriginalContent,
                this.Logo.ThumbnailContent));

            return this;
        }

        public Team UpdateCoach(Coach coach)
        {
            if (this.Coach != coach)
            {
                this.Coach = coach;
            }

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
