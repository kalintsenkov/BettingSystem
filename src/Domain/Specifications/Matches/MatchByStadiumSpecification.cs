namespace BettingSystem.Domain.Specifications.Matches
{
    using System;
    using System.Linq.Expressions;
    using Models.Matches;

    public class MatchByStadiumSpecification : Specification<Match>
    {
        private readonly string? stadium;

        public MatchByStadiumSpecification(string? stadium)
            => this.stadium = stadium;

        protected override bool Include => this.stadium != null;

        public override Expression<Func<Match, bool>> ToExpression()
            => match => match.Stadium.Name.ToLower()
                .Contains(this.stadium!.ToLower());
    }
}
