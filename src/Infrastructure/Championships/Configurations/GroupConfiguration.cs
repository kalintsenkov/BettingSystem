namespace BettingSystem.Infrastructure.Championships.Configurations
{
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Common.Models.ModelConstants.Common;

    internal class GroupConfiguration : IEntityTypeConfiguration<GroupData>
    {
        public void Configure(EntityTypeBuilder<GroupData> builder)
        {
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .HasMany(g => g.Matches)
                .WithOne(m => m.Group)
                .HasForeignKey(m => m.GroupId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
