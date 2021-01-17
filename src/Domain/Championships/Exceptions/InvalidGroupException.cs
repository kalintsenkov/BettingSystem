namespace BettingSystem.Domain.Championships.Exceptions
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
