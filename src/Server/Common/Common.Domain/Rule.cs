namespace BettingSystem.Domain.Common;

public abstract class Rule<T>
{
    public abstract bool IsSatisfiedBy(T value);
}