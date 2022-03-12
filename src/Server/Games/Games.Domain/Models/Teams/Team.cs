namespace BettingSystem.Domain.Games.Models.Teams;

using Common;
using Common.Models;
using Exceptions;

using static Common.Models.ModelConstants.Common;

public class Team : Entity<int>, IAggregateRoot
{
    internal Team(string name, Image logo)
    {
        this.Validate(name);

        this.Name = name;
        this.Logo = logo;
    }

    private Team(string name)
    {
        this.Name = name;

        this.Logo = default!;
    }

    public string Name { get; private set; }

    public Image Logo { get; private set; }

    public Team UpdateName(string name)
    {
        this.Validate(name);

        this.Name = name;

        return this;
    }

    public Team UpdateLogo(byte[] originalContent, byte[] thumbnailContent)
    {
        this.Logo = new Image(originalContent, thumbnailContent);

        return this;
    }

    private void Validate(string name)
        => Guard.ForStringLength<InvalidTeamException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}