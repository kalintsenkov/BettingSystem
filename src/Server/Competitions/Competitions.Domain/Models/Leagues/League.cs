namespace BettingSystem.Domain.Competitions.Models.Leagues;

using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Models;
using Exceptions;
using Teams;

using static Common.Models.ModelConstants.Common;

public class League : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Team> teams;

    internal League(string name, Country country)
    {
        this.Validate(name);

        this.Name = name;
        this.Country = country;

        this.teams = new HashSet<Team>();
    }

    internal League(
        string name,
        Country country,
        HashSet<Team> teams)
    {
        this.Validate(name);

        this.Name = name;
        this.Country = country;
        this.teams = teams;
    }

    private League(string name)
    {
        this.Name = name;

        this.Country = default!;

        this.teams = new HashSet<Team>();
    }

    public string Name { get; private set; }

    public Country Country { get; private set; }

    public IReadOnlyCollection<Team> Teams => this.teams.ToList().AsReadOnly();

    public League UpdateName(string name)
    {
        this.Validate(name);

        this.Name = name;

        return this;
    }

    public League UpdateCountry(Country country)
    {
        if (this.Country != country)
        {
            this.Country = country;
        }

        return this;
    }

    public void AddTeam(Team team) => this.teams.Add(team);

    public void Validate(string name)
        => Guard.ForStringLength<InvalidLeagueException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}