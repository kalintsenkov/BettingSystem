namespace BettingSystem.Infrastructure.Common.Persistence
{
    using System.Collections.Generic;
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
        private readonly Stack<object> savesChangesTracker;

        protected MessageDbContext(
            DbContextOptions options, 
            IEventPublisher eventPublisher)
            : base(options)
        {
            this.eventPublisher = eventPublisher;

            this.savesChangesTracker = new Stack<object>();
        }

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
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventPublisher.Publish(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }
    }
}
