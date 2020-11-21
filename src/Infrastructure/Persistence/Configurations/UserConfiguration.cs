namespace BettingSystem.Infrastructure.Persistence.Configurations
{
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
            => builder
                .HasOne(t => t.Gambler)
                .WithOne()
                .HasForeignKey<User>("GamblerId")
                .OnDelete(DeleteBehavior.Restrict);
    }
}
