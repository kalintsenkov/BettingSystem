namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using AutoMapper;

    internal class StadiumData :
        IMapFrom<Domain.Betting.Models.Matches.Stadium>,
        IMapTo<Domain.Betting.Models.Matches.Stadium>,
        IMapFrom<Domain.Tournaments.Models.Matches.Stadium>,
        IMapTo<Domain.Tournaments.Models.Matches.Stadium>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public ICollection<MatchData> Matches { get; } = new HashSet<MatchData>();

        public void Mapping(Profile mapper)
        {
            mapper
                .CreateMap<
                    StadiumData,
                    Domain.Betting.Models.Matches.Stadium>()
                .ReverseMap();

            mapper
                .CreateMap<
                    StadiumData,
                    Domain.Tournaments.Models.Matches.Stadium>()
                .ReverseMap();
        }
    }
}
