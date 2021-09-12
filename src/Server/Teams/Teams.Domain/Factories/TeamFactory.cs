namespace BettingSystem.Domain.Teams.Factories
{
    using Common.Models.Images;
    using Models;

    internal class TeamFactory : ITeamFactory
    {
        private string teamName = default!;
        private Image teamLogo = default!;

        public ITeamFactory WithName(string name)
        {
            this.teamName = name;
            return this;
        }

        public ITeamFactory WithLogo(
            byte[] logoOriginalContent,
            byte[] logoThumbnailContent)
        {
            this.teamLogo = new Image(logoOriginalContent, logoThumbnailContent);
            return this;
        }

        public Team Build() => new(this.teamName, this.teamLogo);
    }
}
