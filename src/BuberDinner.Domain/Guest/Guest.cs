using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds;
    private readonly List<DinnerId> _pastDinnerIds;
    private readonly List<DinnerId> _pendingDinnerIds;
    private readonly List<BillId> _billIds;
    private readonly List<MenuReviewId> _menuReviewIds;
    private readonly List<Score> _ratings;

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<Score> Ratings => _ratings.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public Guest(
        GuestId guestId,
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        List<DinnerId> upcomingDinnerIds,
        List<DinnerId> pastDinnerIds,
        List<DinnerId> pendingDinnerIds,
        List<BillId> billIds,
        List<MenuReviewId> menuReviewIds,
        List<Score> ratings)
        : base(guestId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        _upcomingDinnerIds = upcomingDinnerIds;
        _pastDinnerIds = pastDinnerIds;
        _pendingDinnerIds = pendingDinnerIds;
        _billIds = billIds;
        _menuReviewIds = menuReviewIds;
        _ratings = ratings;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static Guest Create(
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        List<DinnerId>? upcomingDinnerIds = null,
        List<DinnerId>? pastDinnerIds = null,
        List<DinnerId>? pendingDinnerIds = null,
        List<BillId>? billIds = null,
        List<MenuReviewId>? menuReviewIds = null,
        List<Score>? ratings = null)
    {
        return new Guest(
            GuestId.CreateUnique(),
            userId,
            firstName,
            lastName,
            profileImage,
            AverageRating.CreateNew(),
            upcomingDinnerIds ?? [],
            pastDinnerIds ?? [],
            pendingDinnerIds ?? [],
            billIds ?? [],
            menuReviewIds ?? [],
            ratings ?? []);
    }
}
