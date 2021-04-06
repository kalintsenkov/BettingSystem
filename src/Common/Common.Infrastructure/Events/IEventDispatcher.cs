namespace BettingSystem.Infrastructure.Common.Events
{
    using System.Threading.Tasks;
    using Domain.Common.Events;

    internal interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
