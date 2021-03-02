namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using Application.Common.Mapping;
    using AutoMapper;

    internal class StatusData :
        IMapFrom<Domain.Betting.Models.Matches.Status>,
        IMapTo<Domain.Betting.Models.Matches.Status>,
        IMapFrom<Domain.Matches.Models.Status>,
        IMapTo<Domain.Matches.Models.Status>
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
                    Domain.Matches.Models.Status>()
                .ReverseMap();
        }
    }
}
