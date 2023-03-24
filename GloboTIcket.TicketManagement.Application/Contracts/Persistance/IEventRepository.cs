using GloboTIcket.TicketManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Contracts.Persistance
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime date);
    }
}