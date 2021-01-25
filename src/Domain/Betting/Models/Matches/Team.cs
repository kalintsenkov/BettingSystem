namespace BettingSystem.Domain.Betting.Models.Matches
{
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;

    public class Team : Entity<int>
    {
        internal Team(
            string name,
            int points,
            int leagueId)
        {
            this.Validate(name);

            this.Name = name;
            this.Points = points;
            this.LeagueId = leagueId;
        }

        public string Name { get; private set; }

        public int Points { get; private set; }

        public int LeagueId { get; private set; }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidMatchException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
