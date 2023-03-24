using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GloboTIcket.TicketManagement.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var excecutingAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(excecutingAssembly);
            services.AddMediatR(excecutingAssembly);

            return services;
        }
    }
}