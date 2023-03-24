using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GloboTIcket.TicketManagement.Api.Extensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddApiExtensions(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GloboTicket Ticket Management API"
                });
            });
            return services;
        }
    }
}