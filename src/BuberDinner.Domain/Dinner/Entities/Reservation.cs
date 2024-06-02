using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        ReservationId reservationId,
        GuestId guestId,
        BillId billId,
        int guestCount,
        DateTime? arrivalDateTime = null)
        : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = ReservationStatus.Reserved;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static Reservation Create(
        GuestId guestId,
        BillId billId,
        int guestCount)
    {
        return new Reservation(
            ReservationId.CreateUnique(),
            guestId,
            billId,
            guestCount);
    }
}
