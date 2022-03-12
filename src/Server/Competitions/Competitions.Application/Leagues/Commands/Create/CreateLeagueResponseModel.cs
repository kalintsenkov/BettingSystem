namespace BettingSystem.Application.Competitions.Leagues.Commands.Create;

public class CreateLeagueResponseModel
{
    internal CreateLeagueResponseModel(int id) => this.Id = id;

    public int Id { get; }
}