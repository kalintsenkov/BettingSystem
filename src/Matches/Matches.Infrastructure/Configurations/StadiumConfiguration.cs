namespace BettingSystem.Infrastructure.Matches.Configurations
{
    using Domain.Matches.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Common.Models.ModelConstants.Common;

    internal class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .OwnsOne(s => s.Image, i =>
                {
                    i.WithOwner();

                    i.Property(img => img.OriginalContent).IsRequired();
                    i.Property(img => img.ThumbnailContent).IsRequired();
                });
        }
    }
}
