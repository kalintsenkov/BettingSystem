namespace BettingSystem.Domain.Teams.Factories
{
    using Common.Models.Images;
    using Exceptions;
    using Models;

    internal class TeamFactory : ITeamFactory
    {
        private string teamName = default!;
        private Image teamLogo = default!;
        private Coach teamCoach = default!;

        private bool isNameSet = false;
        private bool isLogoSet = false;
        private bool isCoachSet = false;

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

        public ITeamFactory WithCoach(string name)
        {
            var coach = new Coach(name);

            return this.WithCoach(coach);
        }

        public ITeamFactory WithCoach(Coach coach)
        {
            this.teamCoach = coach;
            this.isCoachSet = true;

            return this;
        }

        public Team Build()
        {
            if (!this.isNameSet || !this.isLogoSet || !this.isCoachSet)
            {
                throw new InvalidTeamException("Name, logo and coach must have a value");
            }

            return new Team(
                this.teamName,
                this.teamLogo,
                this.teamCoach);
        }
    }
}
