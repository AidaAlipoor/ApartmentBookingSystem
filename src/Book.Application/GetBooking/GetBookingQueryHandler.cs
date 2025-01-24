using Book.Application.Abstraction.Data;
using Book.Application.Abstraction.Messaging;
using Book.Domain.Abstraction;
using Dapper;

namespace Book.Application.GetBooking
{
    internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnection;

        public GetBookingQueryHandler(ISqlConnectionFactory sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnection.CreateConnection();

            var sql = """" 
             SELECT
                 id AS Id,
                 apartment_id AS ApartmentId,
                 user_id AS UserId,
                 status AS Status,
                 price_for_period_amount AS PriceAmount,
                 price_for_period_currency AS PriceCurrency,
                 cleaning_fee_amount AS CleaningFeeAmount,
                 cleaning_fee_currency AS CleaningFeeCurrency,
                 amenities_up_charge_amount AS AmenitiesUpChargeAmount,
                 amenities_up_charge_currency AS AmenitiesUpChargeCurrency,
                 total_price_amount AS TotalPriceAmount,
                 total_price_currency AS TotalPriceCurrency,
                 duration_start AS DurationStart,
                 duration_end AS DurationEnd,
                 created_on_utc AS CreatedOnUtc
             FROM bookings
             WHERE id = @BookingId
             """";

            var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
                sql,
                new { request.bookingId}
                );

            return booking;
        }
    }
}
