namespace BettingSystem.Domain.Competitions.Exceptions
{
    using Common;

    public class InvalidMatchException : BaseDomainException
    {
        public InvalidMatchException()
        {
        }

        public InvalidMatchException(string error) => this.Error = error;
    }
}
