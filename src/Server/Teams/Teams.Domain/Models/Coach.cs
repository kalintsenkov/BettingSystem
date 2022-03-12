namespace BettingSystem.Domain.Teams.Models;

using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;

public class Coach : Entity<int>
{
    internal Coach(string name)
    {
        this.Validate(name);

        this.Name = name;
    }

    public string Name { get; private set; }

    private void Validate(string name)
        => Guard.ForStringLength<InvalidTeamException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}