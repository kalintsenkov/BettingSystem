namespace BettingSystem.Infrastructure.Persistence.Configurations
{
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
            => builder
                .HasMany(t => t.Bets)
                .WithOne()
                .IsRequired()
                .Metadata
                .PrincipalToDependent
                .SetField("bets");
    }
}
