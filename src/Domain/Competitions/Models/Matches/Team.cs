namespace BettingSystem.Domain.Competitions.Models.Matches
{
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;
    using static ModelConstants.Team;

    public class Team : Entity<int>
    {
        internal Team(string name, int points)
        {
            this.Validate(name);

            this.Name = name;
            this.Points = points;
        }

        public string Name { get; private set; }

        public int Points { get; private set; }

        public void GivePointsForWin() => this.Points += WinPoints;

        public void GivePointFromDraw() => this.Points += DrawPoint;

        private void Validate(string name)
            => Guard.ForStringLength<InvalidMatchException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
