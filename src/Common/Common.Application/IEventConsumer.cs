namespace BettingSystem.Application.Common
{
    using Domain.Common.Events;
    using MassTransit;

    public interface IEventConsumer<in TEvent> : IConsumer<TEvent>
        where TEvent : class, IDomainEvent
    {
    }
}
