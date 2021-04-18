namespace BettingSystem.Infrastructure.Common.Persistence
{
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Configuration;
    using Domain.Common.Models;
    using Events;
    using Microsoft.EntityFrameworkCore;

    internal abstract class MessageDbContext : DbContext
    {
        private readonly IEventPublisher eventPublisher;

        protected MessageDbContext(
            DbContextOptions options,
            IEventPublisher eventPublisher)
            : base(options)
            => this.eventPublisher = eventPublisher;

        public DbSet<Message> Messages { get; set; } = default!;

        protected abstract Assembly ConfigurationsAssembly { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                var eventMessages = events
                    .ToDictionary(
                        domainEvent => domainEvent,
                        domainEvent => new Message(domainEvent));

                foreach (var (_, message) in eventMessages)
                {
                    this.Add(message);
                }

                await base.SaveChangesAsync(cancellationToken);

                foreach (var (domainEvent, message) in eventMessages)
                {
                    await this.eventPublisher.Publish(domainEvent);

                    message.MarkAsPublished();

                    await base.SaveChangesAsync(cancellationToken);
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
