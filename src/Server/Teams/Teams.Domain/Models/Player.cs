namespace BettingSystem.Domain.Teams.Models;

using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;

public class Player : Entity<int>
{
    internal Player(string name, Position position)
    {
        this.Validate(name);

        this.Name = name;
        this.Position = position;
    }

    private Player(string name)
    {
        this.Name = name;

        this.Position = default!;
    }

    public string Name { get; private set; }

    public Position Position { get; private set; }

    private void Validate(string name)
        => Guard.ForStringLength<InvalidTeamException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}