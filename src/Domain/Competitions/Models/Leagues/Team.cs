namespace BettingSystem.Domain.Competitions.Models.Leagues
{
    using Common;
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;
    using static ModelConstants.Team;

    public class Team : Entity<int>, IAggregateRoot
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

        public string Name { get; private set; }

        public int Points { get; private set; }

        public League League { get; private set; }

        public void GivePointsForWin() => this.Points += WinPoints;

        public void GivePointFromDraw() => this.Points -= DrawPoint;

        private void Validate(string name)
            => Guard.ForStringLength<InvalidTeamException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
