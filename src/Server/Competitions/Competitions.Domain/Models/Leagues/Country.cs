namespace BettingSystem.Domain.Competitions.Models.Leagues;

using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;

public class Country : Entity<int>
{
    internal Country(string name)
    {
        this.Validate(name);

        this.Name = name;
    }

    public string Name { get; private set; }

    public void Validate(string name)
        => Guard.ForStringLength<InvalidLeagueException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}