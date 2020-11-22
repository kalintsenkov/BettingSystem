﻿namespace BettingSystem.Application.Features.Bets.Queries.Details
{
    using AutoMapper;
    using Domain.Common;
    using Domain.Models.Bets;
    using Mapping;

    public class BetDetailsResponseModel : IMapFrom<Bet>
    {
        public int Id { get; private set; }

        public decimal Amount { get; private set; }

        public string HomeTeam { get; private set; } = default!;

        public string AwayTeam { get; private set; } = default!;

        public string Prediction { get; private set; } = default!;

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Bet, BetDetailsResponseModel>()
                .ForMember(b => b.HomeTeam, cfg => cfg
                    .MapFrom(b => b.Match.HomeTeam.Name))
                .ForMember(b => b.AwayTeam, cfg => cfg
                    .MapFrom(b => b.Match.AwayTeam.Name))
                .ForMember(b => b.Prediction, cfg => cfg
                    .MapFrom(b => Enumeration.NameFromValue<Prediction>(
                        b.Prediction.Value)));
    }
}
