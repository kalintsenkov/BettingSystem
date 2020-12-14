namespace BettingSystem.Infrastructure.Betting.Configurations
{
    using Common.Persistence.Models;
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Common.Models.ModelConstants.Common;

    internal class GamblerConfiguration : IEntityTypeConfiguration<GamblerData>
    {
        public void Configure(EntityTypeBuilder<GamblerData> builder)
        {
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<GamblerData>(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(g => g.Bets)
                .WithOne(b => b.Gambler)
                .HasForeignKey(b => b.GamblerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
