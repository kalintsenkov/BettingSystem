namespace BettingSystem.Infrastructure.Teams.Configurations
{
    using Domain.Teams.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Common.Models.ModelConstants.Common;

    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .OwnsOne(p => p.Position, p =>
                {
                    p.WithOwner();

                    p.Property(sts => sts.Value).IsRequired();
                });
        }
    }
}
