namespace BettingSystem.Application.Teams.Queries.Players
{
    using AutoMapper;
    using Common.Mapping;
    using Domain.Teams.Models;

    public class GetTeamPlayersResponseModel : IMapFrom<Player>
    {
        public string Name { get; private set; } = default!;

        public string Position { get; private set; } = default!;

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Player, GetTeamPlayersResponseModel>()
                .ForMember(m => m.Name, cfg => cfg
                    .MapFrom(p => p.Name))
                .ForMember(m => m.Position, cfg => cfg
                    .MapFrom(p => p.Position.Name));
    }
}
