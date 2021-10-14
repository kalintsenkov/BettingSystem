namespace BettingSystem.Domain.Games.Factories.Teams
{
    using Common.Models.Images;
    using Exceptions;
    using Models.Teams;

    internal class TeamFactory : ITeamFactory
    {
        private string teamName = default!;
        private Image teamLogo = default!;

        private bool isNameSet = false;
        private bool isLogoSet = false;

        public ITeamFactory WithName(string name)
        {
            this.teamName = name;
            this.isNameSet = true;

            return this;
        }

        public ITeamFactory WithLogo(
            byte[] logoOriginalContent,
            byte[] logoThumbnailContent)
        {
            this.teamLogo = new Image(
                logoOriginalContent,
                logoThumbnailContent);

            this.isLogoSet = true;

            return this;
        }

        public Team Build()
        {
            if (!this.isNameSet || !this.isLogoSet)
            {
                throw new InvalidTeamException("Name and logo must have a value");
            }

            return new Team(this.teamName, this.teamLogo);
        }
    }
}
