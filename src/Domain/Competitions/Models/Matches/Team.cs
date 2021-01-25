namespace BettingSystem.Domain.Competitions.Models.Matches
{
    using Common.Models;
    using Exceptions;
    using Leagues;

    using static Common.Models.ModelConstants.Common;
    using static ModelConstants.Team;

    public class Team : Entity<int>
    {
        internal Team(
            string name,
            int points,
            League league)
        {
            this.Validate(name);

            this.Name = name;
            this.Points = points;
            this.League = league;
        }

        private Team(string name, int points)
        {
            this.Name = name;
            this.Points = points;

            this.League = default!;
        }

        public string Name { get; private set; }

        public int Points { get; private set; }

        public League League { get; private set; }

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
