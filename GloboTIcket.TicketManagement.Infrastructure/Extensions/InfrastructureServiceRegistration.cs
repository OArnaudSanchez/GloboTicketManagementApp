using GloboTIcket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTIcket.TicketManagement.Application.Models.Mail;
using GloboTIcket.TicketManagement.Infrastructure.FileExport;
using GloboTIcket.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTIcket.TicketManagement.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();
            return services;
        }
    }
}