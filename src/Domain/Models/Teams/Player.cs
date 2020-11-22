namespace BettingSystem.Domain.Models.Teams
{
    using Common;
    using Exceptions;

    using static ModelConstants.Common;

    public class Player : Entity<int>
    {
        internal Player(string name, Position position)
        {
            this.Validate(name);

            this.Name = name;
            this.Position = position;
        }

        private Player(string name)
        {
            this.Name = name;

            this.Position = default!;
        }

        public string Name { get; private set; }

        public Position Position { get; private set; }

        public Player UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        public Player UpdatePosition(Position position)
        {
            this.Position = position;

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
