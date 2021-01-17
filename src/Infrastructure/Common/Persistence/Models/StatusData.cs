namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using Application.Common.Mapping;
    using AutoMapper;

    public class StatusData :
        IMapFrom<Domain.Betting.Models.Matches.Status>,
        IMapTo<Domain.Betting.Models.Matches.Status>,
        IMapFrom<Domain.Competitions.Models.Matches.Status>,
        IMapTo<Domain.Competitions.Models.Matches.Status>
    {
        public int Value { get; set; }

        public void Mapping(Profile mapper)
        {
            mapper
                .CreateMap<
                    StatusData,
                    Domain.Betting.Models.Matches.Status>()
                .ReverseMap();

            mapper
                .CreateMap<
                    StatusData,
                    Domain.Competitions.Models.Matches.Status>()
                .ReverseMap();
        }
    }
}
