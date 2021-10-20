namespace BettingSystem.Infrastructure.Games.Configurations
{
    using Domain.Games.Models.Matches;
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
                .HasOne(s => s.Image)
                .WithMany()
                .HasForeignKey("ImageId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
