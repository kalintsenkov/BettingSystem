namespace BettingSystem.Domain.Games.Factories.Matches
{
    using System;
    using Common;
    using Models.Matches;
    using Models.Teams;

    public interface IMatchFactory : IFactory<Match>
    {
        IMatchFactory WithStartDate(DateTime startDate);

        IMatchFactory WithHomeTeam(Team team);

        IMatchFactory WithAwayTeam(Team team);

        IMatchFactory WithStadium(
            string name,
            byte[] imageOriginal,
            byte[] imageThumbnail);

        IMatchFactory WithStadium(Stadium stadium);
    }
}
