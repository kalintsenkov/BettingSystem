namespace BettingSystem.Domain.Competitions.Exceptions;

using Common;

public class InvalidLeagueException : BaseDomainException
{
    public InvalidLeagueException()
    {
    }

    public InvalidLeagueException(string error) => this.Error = error;
}