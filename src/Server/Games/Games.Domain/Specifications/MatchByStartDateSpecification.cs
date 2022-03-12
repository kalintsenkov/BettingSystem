namespace BettingSystem.Domain.Games.Specifications;

using System;
using System.Linq.Expressions;
using Common;
using Models.Matches;

public class MatchByStartDateSpecification : Specification<Match>
{
    private readonly string? startDate;

    public MatchByStartDateSpecification(string? startDate)
        => this.startDate = startDate;

    protected override bool Include => this.startDate != null;

    public override Expression<Func<Match, bool>> ToExpression()
    {
        var startDateTime = DateTime.Parse(this.startDate!);

        return match =>
            match.StartDate.Day == startDateTime.Day &&
            match.StartDate.Month == startDateTime.Month &&
            match.StartDate.Year == startDateTime.Year;
    }
}