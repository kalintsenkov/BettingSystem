namespace BettingSystem.Domain.Models.Matches
{
    using Common;
    using Exceptions;

    using static ModelConstants.Common;

    public class Stadium : Entity<int>
    {
        public Stadium(string name, string imageUrl)
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
