namespace BettingSystem.Web.Features
{
    using System.Linq;
    using Application;
    using Application.Contracts;
    using Domain.Models.Matches;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    public class MatchesController : ApiController
    {
        private readonly IRepository<Match> matches;
        private readonly IOptions<ApplicationSettings> settings;

        public MatchesController(
            IRepository<Match> matches,
            IOptions<ApplicationSettings> settings)
        {
            this.matches = matches;
            this.settings = settings;
        }

        [HttpGet]
        public ActionResult<object> Get() => new
        {
            Settings = this.settings,
            Matches = this.matches
                .All()
                .ToList()
        };
    }
}
