namespace BettingSystem.Infrastructure.Persistence.Models
{
    using Application.Common.Mapping;
    using AutoMapper;

    internal class StatusData :
        IMapFrom<Domain.Matches.Models.Status>,
        IMapTo<Domain.Matches.Models.Status>
    {
        public int Value { get; set; }

        public void Mapping(Profile mapper)
        {
            mapper
                .CreateMap<
                    StatusData,
                    Domain.Matches.Models.Status>()
                .ReverseMap();
        }
    }
}
