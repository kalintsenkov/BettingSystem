namespace BettingSystem.Infrastructure.Common.Events
{
    using System.Threading.Tasks;
    using Domain.Common.Events;
    using MassTransit;

    internal class EventPublisher : IEventPublisher
    {
        private readonly IBus bus;

        public EventPublisher(IBus bus)
            => this.bus = bus;

        public async Task Publish(IDomainEvent domainEvent)
            => await this.bus.Publish(domainEvent);
    }
}
