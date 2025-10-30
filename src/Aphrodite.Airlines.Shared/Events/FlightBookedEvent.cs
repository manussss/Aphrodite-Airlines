namespace Aphrodite.Airlines.Shared.Events;

public record FlightBookedEvent(
    Guid BookingId,
    Guid FlightId,
    string PassengerName,
    string SeatNumber,
    DateTime BookingDate);