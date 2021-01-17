namespace BettingSystem.Application.Championships.Tournaments
{
    using Common.Contracts;
    using Domain.Championships.Models.Tournaments;

    public interface ITournamentQueryRepository : IQueryRepository<Tournament>
    {
    }
}
