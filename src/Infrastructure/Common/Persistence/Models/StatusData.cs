namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using Application.Common.Mapping;
    using AutoMapper;

    public class StatusData :
        IMapFrom<Domain.Betting.Models.Matches.Status>,
        IMapTo<Domain.Betting.Models.Matches.Status>,
        IMapFrom<Domain.Championships.Models.Matches.Status>,
        IMapTo<Domain.Championships.Models.Matches.Status>
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
                    Domain.Championships.Models.Matches.Status>()
                .ReverseMap();
        }
    }
}
