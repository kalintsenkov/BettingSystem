namespace BettingSystem.Domain.Games.Models.Teams
{
    using Common;
    using Common.Models;
    using Common.Models.Images;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;

    public class Team : Entity<int>, IAggregateRoot
    {
        internal Team(string name, Image image)
        {
            this.Validate(name);

            this.Name = name;
            this.Image = image;
        }

        private Team(string name)
        {
            this.Name = name;

            this.Image = default!;
        }

        public string Name { get; private set; }

        public Image Image { get; private set; }

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
