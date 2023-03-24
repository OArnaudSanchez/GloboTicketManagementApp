using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using GloboTIcket.TicketManagement.Persistance.Context;
using GloboTIcket.TicketManagement.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTIcket.TicketManagement.Persistence.Extensions
{
    public static class PersistenseServiceRegistration
    {
        public static IServiceCollection AddPersistenseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GloboTicketManagementConnectionString"))
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}