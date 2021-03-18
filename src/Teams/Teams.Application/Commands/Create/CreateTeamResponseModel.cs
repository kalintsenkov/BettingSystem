namespace BettingSystem.Application.Teams.Commands.Create
{
    public class CreateTeamResponseModel
    {
        internal CreateTeamResponseModel(int id) => this.Id = id;

        public int Id { get; }
    }
}
