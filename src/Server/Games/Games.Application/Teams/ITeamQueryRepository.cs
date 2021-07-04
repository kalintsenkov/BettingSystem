namespace BettingSystem.Application.Games.Teams
{
    using Common.Contracts;
    using Domain.Games.Models.Teams;

    public interface ITeamQueryRepository : IQueryRepository<Team>
    {
    }
}
