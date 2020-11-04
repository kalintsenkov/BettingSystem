namespace BettingSystem.Domain.Exceptions
{
    using System;
    using Common;

    public class InvalidTeamException : BaseDomainException
    {
        public InvalidTeamException()
        {
        }

        public InvalidTeamException(string error) => this.Error = error;
    }
}
