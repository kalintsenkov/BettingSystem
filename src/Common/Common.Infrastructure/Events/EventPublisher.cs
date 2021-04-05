namespace BettingSystem.Infrastructure.Common.Events
{
    using System.Threading.Tasks;
    using Domain.Common.Events;
    using MassTransit;

    internal class EventPublisher : IEventPublisher
    {
        private readonly IBus publisher;

        public EventPublisher(IBus publisher)
            => this.publisher = publisher;

        public async Task Publish(IDomainEvent domainEvent)
            => await this.publisher.Publish(domainEvent);
    }
}
