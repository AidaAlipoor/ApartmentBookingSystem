using Book.Application.Abstraction.Behavior;
using Book.Domain.Booking;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddTransient<PricingService>();

            return services;
        }
    }
}
