using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds;
    private readonly List<DinnerId> _dinnerIds;

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Host(
        HostId hostId,
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        List<MenuId> menuIds,
        List<DinnerId> dinnerIds)
        : base(hostId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
        _menuIds = menuIds;
        _dinnerIds = dinnerIds;
    }

    public static Host Create(
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        List<MenuId>? menuIds = null,
        List<DinnerId>? dinnerIds = null)
    {
        return new Host(
            HostId.CreateUnique(),
            userId,
            firstName,
            lastName,
            profileImage,
            AverageRating.CreateNew(),
            menuIds ?? [],
            dinnerIds ?? []);
    }
}
