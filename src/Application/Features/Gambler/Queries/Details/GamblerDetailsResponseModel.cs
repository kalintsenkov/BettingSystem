namespace BettingSystem.Application.Features.Gambler.Queries.Details
{
    using AutoMapper;
    using Domain.Models.Gamblers;
    using Mapping;

    public class GamblerDetailsResponseModel : IMapFrom<Gambler>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public int TotalBets { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Gambler, GamblerDetailsResponseModel>()
                .ForMember(m => m.TotalBets, cfg => cfg
                    .MapFrom(g => g.Bets.Count));
    }
}
