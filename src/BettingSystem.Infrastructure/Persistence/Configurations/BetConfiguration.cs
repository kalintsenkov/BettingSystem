namespace BettingSystem.Infrastructure.Persistence.Configurations
{
    using Domain.Models.Bets;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder
                .Property(b => b.Id);

            builder
                .Property(b => b.Amount)
                .HasPrecision(19, 4)
                .IsRequired();

            builder
                .HasOne(b => b.Match)
                .WithMany()
                .HasForeignKey("MatchId")
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
