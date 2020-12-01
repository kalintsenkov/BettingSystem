namespace BettingSystem.Domain.Betting.Models.Matches
{
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;

    public class Stadium : Entity<int>
    {
        internal Stadium(string name, string imageUrl)
        {
            this.Validate(name, imageUrl);

            this.Name = name;
            this.ImageUrl = imageUrl;
        }

        public string Name { get; }

        public string ImageUrl { get; }

        private void Validate(string name, string image)
        {
            Guard.ForStringLength<InvalidMatchException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

            Guard.ForValidUrl<InvalidMatchException>(
                image,
                nameof(this.ImageUrl));
        }
    }
}
