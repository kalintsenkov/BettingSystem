namespace BettingSystem.Domain.Specifications.Matches
{
    using System;
    using System.Linq.Expressions;
    using Models.Matches;

    public class MatchByAwayTeamSpecification : Specification<Match>
    {
        private readonly string? awayTeam;

        public MatchByAwayTeamSpecification(string? awayTeam)
            => this.awayTeam = awayTeam;

        protected override bool Include => this.awayTeam != null;

        public override Expression<Func<Match, bool>> ToExpression()
            => match => match.AwayTeam.Name.ToLower()
                .Contains(this.awayTeam!.ToLower());
    }
}
