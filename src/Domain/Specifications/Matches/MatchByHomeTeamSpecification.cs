namespace BettingSystem.Domain.Specifications.Matches
{
    using System;
    using System.Linq.Expressions;
    using Models.Matches;

    public class MatchByHomeTeamSpecification : Specification<Match>
    {
        private readonly string? homeTeam;

        public MatchByHomeTeamSpecification(string? homeTeam)
            => this.homeTeam = homeTeam;

        protected override bool Include => this.homeTeam != null;

        public override Expression<Func<Match, bool>> ToExpression()
            => match => match.HomeTeam.Name.ToLower()
                .Contains(this.homeTeam!.ToLower());
    }
}
