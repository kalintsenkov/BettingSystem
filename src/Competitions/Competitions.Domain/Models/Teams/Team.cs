namespace BettingSystem.Domain.Competitions.Models.Teams
{
    using Common;
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;
    using static ModelConstants.Team;

    public class Team : Entity<int>, IAggregateRoot
    {
        internal Team(string name, int points)
        {
            this.Validate(name);

            this.Name = name;
            this.Points = points;
        }

        public string Name { get; private set; }

        public int Points { get; private set; }

        public Team UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        public void GivePointsForWin() => this.Points += WinPoints;

        public void GivePointFromDraw() => this.Points += DrawPoint;

        private void Validate(string name)
            => Guard.ForStringLength<InvalidTeamException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
