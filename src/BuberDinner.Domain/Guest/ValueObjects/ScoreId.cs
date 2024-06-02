using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public sealed class ScoreId : ValueObject
{
    public Guid Value { get; }

    private ScoreId(Guid value)
    {
        Value = value;
    }

    public static ScoreId CreateUnique()
    {
        return new ScoreId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
