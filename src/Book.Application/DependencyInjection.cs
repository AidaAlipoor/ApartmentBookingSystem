﻿using Book.Application.Abstraction.Behavior;
using Book.Domain.Booking;
using FluentValidation;
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
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddTransient<PricingService>();

            return services;
        }
    }
}
