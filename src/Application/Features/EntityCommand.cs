namespace BettingSystem.Application.Features
{
    public class EntityCommand<TId, TCommand>
        where TCommand : EntityCommand<TId, TCommand>
    {
        public TId Id { get; set; } = default!;

        public TCommand SetId(TId id)
        {
            this.Id = id;
            return (TCommand)this;
        }
    }
}
