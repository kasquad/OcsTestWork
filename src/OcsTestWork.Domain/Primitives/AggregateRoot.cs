namespace OcsTestWork.Domain.Primitives;

public class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public AggregateRoot(Guid id) 
        : base(id)
    {
        
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}