using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcsTestWork.Persistence.Primitives;

public abstract class EntityDb
{
    public Guid Id { get; set; }
}