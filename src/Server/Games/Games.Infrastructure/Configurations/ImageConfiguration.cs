namespace BettingSystem.Infrastructure.Games.Configurations;

using Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder
            .HasKey(i => i.Id);

        builder
            .Property(i => i.OriginalContent)
            .IsRequired();

        builder
            .Property(i => i.ThumbnailContent)
            .IsRequired();
    }
}