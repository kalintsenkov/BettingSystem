namespace BettingSystem.Domain.Matches.Models.Matches
{
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;

    public class Stadium : Entity<int>
    {
        internal Stadium(string name, Image image)
        {
            this.Validate(name);

            this.Name = name;
            this.Image = image;
        }

        private Stadium(string name)
        {
            this.Name = name;

            this.Image = default!;
        }

        public string Name { get; private set; }

        public Image Image { get; private set; }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidMatchException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
