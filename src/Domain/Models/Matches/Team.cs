namespace BettingSystem.Domain.Models.Matches
{
    using Common;
    using Exceptions;

    using static ModelConstants.Common;

    public class Team : Entity<int>
    {
        internal Team(string name)
        {
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidTeamException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
