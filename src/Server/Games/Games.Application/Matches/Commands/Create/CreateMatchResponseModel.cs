namespace BettingSystem.Application.Games.Matches.Commands.Create
{
    public class CreateMatchResponseModel
    {
        internal CreateMatchResponseModel(int id) => this.Id = id;

        public int Id { get; }
    }
}
