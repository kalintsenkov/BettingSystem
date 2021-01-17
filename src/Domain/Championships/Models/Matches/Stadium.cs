namespace BettingSystem.Domain.Championships.Models.Matches
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

        public string Name { get; private set; }

        public string ImageUrl { get; private set; }

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
