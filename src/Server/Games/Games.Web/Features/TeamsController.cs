namespace BettingSystem.Web.Games.Features
{
    using System.Threading.Tasks;
    using Application.Games.Teams.Queries.OriginalLogo;
    using Application.Games.Teams.Queries.ThumbnailLogo;
    using Common;
    using Microsoft.AspNetCore.Mvc;

    public class TeamsController : ApiController
    {
        [HttpGet]
        [Route(Id + PathSeparator + nameof(OriginalLogo))]
        public async Task<ActionResult> OriginalLogo(
            [FromRoute] TeamOriginalLogoQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id + PathSeparator + nameof(ThumbnailLogo))]
        public async Task<ActionResult> ThumbnailLogo(
            [FromRoute] TeamThumbnailLogoQuery query)
            => await this.Send(query);
    }
}
