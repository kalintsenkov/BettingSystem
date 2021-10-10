namespace BettingSystem.Infrastructure.Competitions.Configurations
{
    using Domain.Competitions.Models.Leagues;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Common.Models.ModelConstants.Common;

    internal class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .HasOne(m => m.Country)
                .WithMany()
                .HasForeignKey("CountryId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(l => l.Teams)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("teams");
        }
    }
}
