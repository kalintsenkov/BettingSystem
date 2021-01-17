namespace BettingSystem.Domain.Competitions.Factories.Groups
{
    using Exceptions;
    using Models.Groups;
    using Models.Tournaments;

    internal class GroupFactory : IGroupFactory
    {
        private string groupName = default!;
        private Tournament groupTournament = default!;

        private bool isTournamentSet = false;

        public IGroupFactory WithName(string name)
        {
            this.groupName = name;
            return this;
        }

        public IGroupFactory WithTournament(Tournament tournament)
        {
            this.groupTournament = tournament;
            this.isTournamentSet = true;
            return this;
        }

        public Group Build()
        {
            if (!this.isTournamentSet)
            {
                throw new InvalidGroupException(
                    "Tournament must have a value.");
            }

            return new Group(
                this.groupName,
                this.groupTournament);
        }
    }
}
