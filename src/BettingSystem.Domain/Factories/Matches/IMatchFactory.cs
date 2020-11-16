namespace BettingSystem.Domain.Factories.Matches
{
    using System;
    using Models.Matches;
    using Models.Teams;

    public interface IMatchFactory : IFactory<Match>
    {
        IMatchFactory WithStartDate(DateTime startDate);

        IMatchFactory WithHomeTeam(string teamName);

        IMatchFactory WithHomeTeam(Team team);

        IMatchFactory WithAwayTeam(string teamName);

        IMatchFactory WithAwayTeam(Team team);

        IMatchFactory WithStadium(string name, string imageUrl);

        IMatchFactory WithStadium(Stadium stadium);

        IMatchFactory WithStatistics(int? homeScore, int? awayScore);
    }
}
