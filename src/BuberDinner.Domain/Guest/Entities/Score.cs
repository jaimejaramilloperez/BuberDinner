using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

public sealed class Score : Entity<ScoreId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Score(
        ScoreId ratingId,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating)
        : base(ratingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static Score Create(
        HostId hostId,
        DinnerId dinnerId,
        double rating)
    {
        return new Score(
            ScoreId.CreateUnique(),
            hostId,
            dinnerId,
            Rating.CreateNew(rating));
    }
}
