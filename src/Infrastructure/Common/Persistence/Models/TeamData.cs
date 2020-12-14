namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Betting.Models.Matches;

    internal class TeamData : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<TeamData, Team>()
                .ReverseMap();
    }
}
