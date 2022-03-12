namespace BettingSystem.Infrastructure.Common.Events;

using System;
using System.Threading.Tasks;
using Domain.Common.Events;

internal interface IEventPublisher
{
    Task Publish(IDomainEvent domainEvent);

    Task Publish<TDomainEvent>(TDomainEvent domainEvent, Type domainEventType);
}