namespace BettingSystem.Infrastructure.Teams.Configurations
{
    using Domain.Teams.Models;
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
                .HasMany(t => t.Players)
                .WithOne()
                .IsRequired()
                .Metadata
                .PrincipalToDependent
                .SetField("players");
        }
    }
}
