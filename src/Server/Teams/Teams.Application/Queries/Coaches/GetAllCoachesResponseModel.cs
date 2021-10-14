namespace BettingSystem.Application.Teams.Queries.Coaches
{
    using Common.Mapping;
    using Domain.Teams.Models;

    public class GetAllCoachesResponseModel : IMapFrom<Coach>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;
    }
}
