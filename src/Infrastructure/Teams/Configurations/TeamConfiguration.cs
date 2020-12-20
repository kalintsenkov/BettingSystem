namespace BettingSystem.Infrastructure.Teams.Configurations
{
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Common.Models.ModelConstants.Common;

    internal class TeamConfiguration : IEntityTypeConfiguration<TeamData>
    {
        public void Configure(EntityTypeBuilder<TeamData> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .HasMany(t => t.Players)
                .WithOne()
                .HasForeignKey("TeamId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
