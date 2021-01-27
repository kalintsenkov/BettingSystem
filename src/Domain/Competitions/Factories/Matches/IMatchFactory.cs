namespace BettingSystem.Domain.Competitions.Factories.Matches
{
    using System;
    using Common;
    using Models.Matches;

    public interface IMatchFactory : IFactory<Match>
    {
        IMatchFactory WithStartDate(DateTime startDate);

        IMatchFactory WithHomeTeam(Team team);

        IMatchFactory WithAwayTeam(Team team);

        IMatchFactory WithStadium(
            string name,
            byte[] originalContent,
            byte[] thumbnailContent);

        IMatchFactory WithStadium(Stadium stadium);
    }
}
