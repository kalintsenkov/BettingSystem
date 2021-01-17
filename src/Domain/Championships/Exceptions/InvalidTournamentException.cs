namespace BettingSystem.Domain.Championships.Exceptions
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
