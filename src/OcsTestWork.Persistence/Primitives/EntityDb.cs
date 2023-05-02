namespace OcsTestWork.Persistence.Primitives;

/// <summary>
/// New guid auto generate.
/// </summary>
public abstract class EntityDb
{
    public Guid Id { get; set; } = Guid.NewGuid();
}