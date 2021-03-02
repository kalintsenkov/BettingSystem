namespace BettingSystem.Infrastructure.Competitions.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persistence.Models;
    using static Domain.Common.Models.ModelConstants.Common;

    internal class LeagueConfiguration : IEntityTypeConfiguration<LeagueData>
    {
        public void Configure(EntityTypeBuilder<LeagueData> builder)
        {
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .HasMany(l => l.Teams)
                .WithOne(t => t.League)
                .HasForeignKey(t => t.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
