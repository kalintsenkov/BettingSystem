namespace BettingSystem.Domain.Competitions.Exceptions
{
    using Common;

    public class InvalidGroupException : BaseDomainException
    {
        public InvalidGroupException()
        {
        }

        public InvalidGroupException(string error) => this.Error = error;
    }
}
