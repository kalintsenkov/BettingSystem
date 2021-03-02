namespace BettingSystem.Infrastructure.Betting.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persistence.Models;

    internal class BetConfiguration : IEntityTypeConfiguration<BetData>
    {
        public void Configure(EntityTypeBuilder<BetData> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Amount)
                .HasPrecision(19, 4)
                .IsRequired();

            builder
                .HasOne(b => b.Match)
                .WithMany(m => m.Bets)
                .HasForeignKey(b => b.MatchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(b => b.Prediction, p =>
                {
                    p.WithOwner();

                    p.Property(pr => pr.Value).IsRequired();
                });
        }
    }
}
