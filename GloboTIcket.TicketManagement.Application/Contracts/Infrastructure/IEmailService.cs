using GloboTIcket.TicketManagement.Application.Models.Mail;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}