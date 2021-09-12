namespace BettingSystem.Domain.Teams.Factories
{
    using Common.Models.Images;
    using Models;

    internal class TeamFactory : ITeamFactory
    {
        private string teamName = default!;
        private Image teamImage = default!;

        public ITeamFactory WithName(string name)
        {
            this.teamName = name;
            return this;
        }

        public ITeamFactory WithImage(
            byte[] imageOriginal, 
            byte[] imageThumbnail)
        {
            this.teamImage = new Image(imageOriginal, imageThumbnail);
            return this;
        }

        public Team Build() => new(this.teamName, this.teamImage);
    }
}
