namespace BettingSystem.Infrastructure.Matches.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persistence.Models;
    using static Domain.Common.Models.ModelConstants.Common;

    internal class StadiumConfiguration : IEntityTypeConfiguration<StadiumData>
    {
        public void Configure(EntityTypeBuilder<StadiumData> builder)
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
