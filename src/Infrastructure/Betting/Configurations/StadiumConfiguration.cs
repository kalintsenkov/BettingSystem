namespace BettingSystem.Infrastructure.Betting.Configurations
{
    using Domain.Betting.Models.Matches;
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
                .Property(s => s.ImageUrl)
                .HasMaxLength(MaxUrlLength)
                .IsRequired();
        }
    }
}
