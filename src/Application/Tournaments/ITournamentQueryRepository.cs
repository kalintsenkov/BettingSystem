namespace BettingSystem.Application.Tournaments
{
    using Common.Contracts;
    using Domain.Tournaments.Models.Tournaments;

    public interface ITournamentQueryRepository : IQueryRepository<Tournament>
    {
    }
}
