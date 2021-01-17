namespace BettingSystem.Application.Competitions.Groups.Commands.Create
{
    public class CreateGroupResponseModel
    {
        internal CreateGroupResponseModel(int id) => this.Id = id;

        public int Id { get; }
    }
}
