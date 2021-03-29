namespace BettingSystem.Infrastructure.Common.Persistence
{
    using System.Reflection;
    using Configuration;
    using Domain.Common.Models;
    using Microsoft.EntityFrameworkCore;

    internal abstract class MessageDbContext : DbContext
    {
        protected MessageDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; } = default!;

        protected abstract Assembly ConfigurationsAssembly { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }
    }
}
