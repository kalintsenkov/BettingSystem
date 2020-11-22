namespace BettingSystem.Application.Features.Bets.Commands.Create
{
    public class CreateBetResponseModel
    {
        internal CreateBetResponseModel(int id) => this.Id = id;

        public int Id { get; }
    }
}
