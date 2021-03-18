namespace BettingSystem.Domain.Competitions.Exceptions
{
    using Common;

    public class InvalidTeamException : BaseDomainException
    {
        public InvalidTeamException()
        {
        }

        public InvalidTeamException(string error) => this.Error = error;
    }
}
