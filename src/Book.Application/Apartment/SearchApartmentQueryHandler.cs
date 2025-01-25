using Book.Application.Abstraction.Data;
using Book.Application.Abstraction.Messaging;
using Book.Domain.Abstraction;
using Book.Domain.Booking;
using Dapper;

namespace Book.Application.Apartment
{
    internal sealed class SearchApartmentQueryHandler : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnection;

        private static readonly int[] ActiveBookingStatuses =
        {
            (int)BookingStatus.Reserved,
            (int)BookingStatus.Confirmed,
            (int)BookingStatus.Completed
        };

        public SearchApartmentQueryHandler(ISqlConnectionFactory sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentsQuery request, CancellationToken cancellationToken)
        {
            if (request.startDate > request.endDate)
            {
                return new List<ApartmentResponse>();
            }

            var connection = _sqlConnection.CreateConnection();

            const string sql = """
             SELECT
                a.id AS Id,
                a.name AS Name,
                a.description AS Description,
                a.price_amount AS Price,
                a.price_currency AS Currency,
                a.address_country AS Country,
                a.address_state AS State,
                a.address_zip_code AS ZipCode,
                a.address_city AS City,
                a.address_street AS Street
              FROM apartments AS a
              WHERE NOT EXISTS
              (
                SELECT 1
                FROM bookings AS b
                WHERE
                    b.apartment_id = a.id AND
                    b.duration_start <= @EndDate AND
                    b.duration_end >= @StartDate AND
                    b.status = ANY(@ActiveBookingStatuses)
              )
             """;

            var apartments = await connection
            .QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
                sql,
                (apartment, address) =>
                {
                    apartment.Address = address;

                    return apartment;
                },
                new
                {
                    request.startDate,
                    request.endDate,
                    ActiveBookingStatuses
                },
                splitOn: "Country");

            return apartments.ToList();
        }
    }
}
