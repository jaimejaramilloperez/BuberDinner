using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations;

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Uri ImageUrl { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public Location Location { get; private set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Dinner(
        DinnerId dinnerId,
        HostId hostId,
        MenuId menuId,
        string name,
        string description,
        Uri imageUrl,
        bool isPublic,
        int maxGuests,
        Price price,
        Location location,
        DateTime startDateTime,
        DateTime endDateTime,
        List<Reservation> reservations,
        DateTime? startedDateTime = null,
        DateTime? endedDateTime = null)
        : base(dinnerId)
    {
        HostId = hostId;
        MenuId = menuId;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        Location = location;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        _reservations = reservations;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = DinnerStatus.Upcoming;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static Dinner Create(
        HostId hostId,
        MenuId menuId,
        string name,
        string description,
        Uri imageUrl,
        bool isPublic,
        int maxGuests,
        Price price,
        Location location,
        DateTime startDateTime,
        DateTime endDateTime,
        List<Reservation>? reservations = null)
    {
        return new Dinner(
            DinnerId.CreateUnique(),
            hostId,
            menuId,
            name,
            description,
            imageUrl,
            isPublic,
            maxGuests,
            price,
            location,
            startDateTime,
            endDateTime,
            reservations ?? []);
    }
}
