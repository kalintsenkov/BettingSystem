namespace BettingSystem.Infrastructure.Games.Configurations;

using Domain.Games.Models.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .HasOne(t => t.Logo)
            .WithMany()
            .HasForeignKey("LogoId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}