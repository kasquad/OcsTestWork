using System.Reflection;

namespace OcsTestWork.Domain.Primitives;

public abstract class Enumeration : IComparable
{
    public string Name { get; }
    public Int16 Id { get; }

    protected Enumeration(Int16 id, string name) => (Id, Name) = (id, name);
    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    public override bool Equals(object obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typesMatches = GetType() == obj.GetType();
        var valueMatches = Id.Equals(otherValue.Id);

        return typesMatches && valueMatches;
    }

    protected bool Equals(Enumeration other) =>
        Name == other.Name && Id == other.Id;

    public override int GetHashCode() =>
        HashCode.Combine(Name, Id);

    public int CompareTo(object? obj) =>
        Id.CompareTo(((Enumeration)obj).Id);
}