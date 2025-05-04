using Book.Application.Abstraction.Clock;
using Book.Application.Abstraction.Data;
using Book.Application.Abstraction.Email;
using Book.Domain.Abstraction;
using Book.Domain.Apartment.Repository;
using Book.Domain.Booking.Repository;
using Book.Domain.Users.IUserRepository;
using Book.Infrastructure.Clock;
using Book.Infrastructure.Data;
using Book.Infrastructure.Email;
using Book.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("Database")
                ?? throw new ArgumentNullException(nameof(configuration));
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer());

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(s => new SqlConnectionFactory(connectionString));

            return services;
        }
    }
}
