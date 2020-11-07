namespace BettingSystem.Web.Features
{
    using System.Collections.Generic;
    using Application.Contracts;
    using Domain.Models.Matches;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class MatchesController
    {
        private readonly IRepository<Match> matches;

        public MatchesController(IRepository<Match> matches)
            => this.matches = matches;

        [HttpGet]
        public IEnumerable<Match> Get() => this.matches.All();
    }
}
