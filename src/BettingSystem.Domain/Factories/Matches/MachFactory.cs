namespace BettingSystem.Domain.Factories.Matches
{
    using System;
    using Exceptions;
    using Models.Matches;
    using Models.Teams;

    internal class MachFactory : IMatchFactory
    {
        private DateTime matchStartDate = default!;
        private Team matchHomeTeam = default!;
        private Team matchAwayTeam = default!;
        private Stadium matchStadium = default!;
        private Statistics matchStatistics = default!;

        private bool isHomeTeamSet = false;
        private bool isAwayTeamSet = false;
        private bool isStadiumSet = false;

        public IMatchFactory WithStartDate(DateTime startDate)
        {
            this.matchStartDate = startDate;
            return this;
        }

        public IMatchFactory WithHomeTeam(string teamName)
            => this.WithHomeTeam(new Team(teamName));

        public IMatchFactory WithHomeTeam(Team team)
        {
            this.matchHomeTeam = team;
            this.isHomeTeamSet = true;
            return this;
        }

        public IMatchFactory WithAwayTeam(string teamName)
            => this.WithAwayTeam(new Team(teamName));

        public IMatchFactory WithAwayTeam(Team team)
        {
            this.matchAwayTeam = team;
            this.isAwayTeamSet = true;
            return this;
        }

        public IMatchFactory WithStadium(string name, string imageUrl)
            => this.WithStadium(new Stadium(name, imageUrl));

        public IMatchFactory WithStadium(Stadium stadium)
        {
            this.matchStadium = stadium;
            this.isStadiumSet = true;
            return this;
        }

        public IMatchFactory WithStatistics(int? homeScore, int? awayScore)
            => this.WithStatistics(new Statistics(homeScore, awayScore));

        public IMatchFactory WithStatistics(Statistics statistics)
        {
            this.matchStatistics = statistics;
            return this;
        }

        public Match Build()
        {
            if (!this.isHomeTeamSet || !this.isAwayTeamSet || !this.isStadiumSet)
            {
                throw new InvalidMatchException(
                    "Home team, away team and stadium must have a value.");
            }

            return new Match(
                this.matchStartDate,
                this.matchHomeTeam,
                this.matchAwayTeam,
                this.matchStadium,
                this.matchStatistics);
        }
    }
}
