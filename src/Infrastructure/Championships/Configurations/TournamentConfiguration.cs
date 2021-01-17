namespace BettingSystem.Infrastructure.Championships.Configurations
{
    using Common.Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Common.Models.ModelConstants.Common;

    internal class TournamentConfiguration : IEntityTypeConfiguration<TournamentData>
    {
        public void Configure(EntityTypeBuilder<TournamentData> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .HasMany(t => t.Groups)
                .WithOne(m => m.Tournament)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
