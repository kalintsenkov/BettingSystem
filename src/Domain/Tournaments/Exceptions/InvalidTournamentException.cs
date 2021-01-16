namespace BettingSystem.Domain.Tournaments.Exceptions
{
    using Common;

    public class InvalidTournamentException : BaseDomainException
    {
        public InvalidTournamentException()
        {
        }

        public InvalidTournamentException(string error) => this.Error = error;
    }
}
