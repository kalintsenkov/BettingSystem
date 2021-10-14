namespace BettingSystem.Domain.Teams.Factories
{
    using Common;
    using Models;

    public interface ITeamFactory : IFactory<Team>
    {
        ITeamFactory WithName(string name);

        ITeamFactory WithLogo(
            byte[] logoOriginalContent,
            byte[] logoThumbnailContent);

        ITeamFactory WithCoach(string name);

        ITeamFactory WithCoach(Coach coach);
    }
}