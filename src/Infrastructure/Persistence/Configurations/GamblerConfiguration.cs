namespace BettingSystem.Infrastructure.Persistence.Configurations
{
    using Domain.Models.Gamblers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Models.ModelConstants.Common;

    internal class GamblerConfiguration : IEntityTypeConfiguration<Gambler>
    {
        public void Configure(EntityTypeBuilder<Gambler> builder)
        {
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .HasMany(g => g.Bets)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("bets");
        }
    }
}
