namespace BettingSystem.Domain.Competitions.Factories.Teams;

using Exceptions;
using Models.Teams;

internal class TeamFactory : ITeamFactory
{
    private string teamName = default!;

    private bool isNameSet = false;

    public ITeamFactory WithName(string name)
    {
        this.teamName = name;
        this.isNameSet = true;

        return this;
    }

    public Team Build()
    {
        if (!this.isNameSet)
        {
            throw new InvalidTeamException("Name must have a value");
        }

        return new Team(this.teamName, points: 0);
    }

    public Team Build(string name)
        => this.WithName(name).Build();
}