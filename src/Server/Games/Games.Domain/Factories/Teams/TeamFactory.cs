namespace BettingSystem.Domain.Games.Factories.Teams
{
    using Common.Models.Images;
    using Models.Teams;

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
