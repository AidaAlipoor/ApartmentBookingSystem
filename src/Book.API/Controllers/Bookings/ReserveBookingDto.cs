namespace Book.API.Controllers.Bookings
{
    public sealed record ReserveBookingDto(
        Guid ApartmentId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate);
}
