namespace BettingSystem.Application.Games.Matches.Queries.Search;

using System.Collections.Generic;
using Common;

public class SearchMatchesResponseModel
{
    internal SearchMatchesResponseModel(IEnumerable<MatchResponseModel> matches)
        => this.Matches = matches;

    public IEnumerable<MatchResponseModel> Matches { get; }
}