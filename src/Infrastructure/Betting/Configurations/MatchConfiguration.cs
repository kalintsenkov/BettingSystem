namespace BettingSystem.Infrastructure.Betting.Configurations
{
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class MatchConfiguration : IEntityTypeConfiguration<MatchData>
    {
        public void Configure(EntityTypeBuilder<MatchData> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.StartDate)
                .IsRequired();

            builder
                .HasOne(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.AwayTeam)
                .WithMany()
                .HasForeignKey(m => m.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Stadium)
                .WithMany()
                .HasForeignKey(m => m.StadiumId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(m => m.Statistics, s =>
                {
                    s.WithOwner();

                    s.Property(st => st.HomeScore);
                    s.Property(st => st.AwayScore);
                });

            builder
                .OwnsOne(st => st.Status, st =>
                {
                    st.WithOwner();

                    st.Property(sts => sts.Value).IsRequired();
                });
        }
    }
}
