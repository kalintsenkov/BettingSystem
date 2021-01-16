namespace BettingSystem.Application.Tournaments.Commands.Create
{
    public class CreateTournamentResponseModel
    {
        internal CreateTournamentResponseModel(int id) => this.Id = id;

        public int Id { get; }
    }
}
