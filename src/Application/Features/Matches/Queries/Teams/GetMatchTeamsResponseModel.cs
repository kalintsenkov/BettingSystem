namespace BettingSystem.Application.Features.Matches.Queries.Teams
{
    using Domain.Models.Matches;
    using Mapping;

    public class GetMatchTeamsResponseModel : IMapFrom<Team>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;
    }
}
