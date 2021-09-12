namespace BettingSystem.Domain.Games.Factories.Teams
{
    using Common;
    using Models.Teams;

    public interface ITeamFactory : IFactory<Team>
    {
        ITeamFactory WithName(string name);

        ITeamFactory WithImage(
            byte[] imageOriginal,
            byte[] imageThumbnail);
    }
}