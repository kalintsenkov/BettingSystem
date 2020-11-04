namespace BettingSystem.Web.Features
{
    using System;
    using Domain.Models.Matches;
    using Domain.Models.Teams;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class MatchesController
    {
        private static readonly Match Match = new Match(
            DateTime.UtcNow.AddDays(2),
            new Team("Real Madrid"),
            new Team("Barcelona"),
            new Stadium(
                "Camp Nou",
                "https://cdn.getyourguide.com/img/tour/55b7a8e0acc59.jpeg/148.jpg"),
            new Statistics(0, 0));

        [HttpGet]
        public ActionResult<Match> Get() => Match;
    }
}
