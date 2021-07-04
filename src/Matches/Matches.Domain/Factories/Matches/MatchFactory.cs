namespace BettingSystem.Domain.Matches.Factories.Matches
{
    using System;
    using Exceptions;
    using Models.Matches;
    using Models.Teams;

    internal class MatchFactory : IMatchFactory
    {
        private readonly Status defaultMatchStatus = Status.NotStarted;
        private readonly Statistics defaultMatchStatistics = new(homeScore: null, awayScore: null);

        private DateTime matchStartDate = default!;
        private Team matchHomeTeam = default!;
        private Team matchAwayTeam = default!;
        private Stadium matchStadium = default!;

        private bool isHomeTeamSet = false;
        private bool isAwayTeamSet = false;
        private bool isStadiumSet = false;

        public IMatchFactory WithStartDate(DateTime startDate)
        {
            this.matchStartDate = startDate;
            return this;
        }

        public IMatchFactory WithHomeTeam(Team team)
        {
            this.matchHomeTeam = team;
            this.isHomeTeamSet = true;
            return this;
        }

        public IMatchFactory WithAwayTeam(Team team)
        {
            this.matchAwayTeam = team;
            this.isAwayTeamSet = true;
            return this;
        }

        public IMatchFactory WithStadium(
            string name,
            byte[] originalContent,
            byte[] thumbnailContent)
        {
            var image = new Image(originalContent, thumbnailContent);
            var stadium = new Stadium(name, image);

            return this.WithStadium(stadium);
        }

        public IMatchFactory WithStadium(Stadium stadium)
        {
            this.matchStadium = stadium;
            this.isStadiumSet = true;
            return this;
        }

        public Match Build()
        {
            if (!this.isHomeTeamSet || !this.isAwayTeamSet || !this.isStadiumSet)
            {
                throw new InvalidMatchException(
                    "Home team, away team, stadium must have a value.");
            }

            return new Match(
                this.matchStartDate,
                this.matchHomeTeam,
                this.matchAwayTeam,
                this.matchStadium,
                this.defaultMatchStatistics,
                this.defaultMatchStatus);
        }
    }
}
