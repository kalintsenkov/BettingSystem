namespace BettingSystem.Domain.Games.Exceptions
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
