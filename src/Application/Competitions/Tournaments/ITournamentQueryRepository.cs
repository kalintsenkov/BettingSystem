namespace BettingSystem.Application.Competitions.Tournaments
{
    using Common.Contracts;
    using Domain.Competitions.Models.Tournaments;

    public interface ITournamentQueryRepository : IQueryRepository<Tournament>
    {
    }
}
