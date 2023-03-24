using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using GloboTIcket.TicketManagement.Domain.Entities;
using GloboTIcket.TicketManagement.Persistance.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Persistance.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime date)
        {
            var matches = _dbContext.Events.Any(x => x.Name.Equals(name) && x.Date.Date.Equals(date));
            return Task.FromResult(matches);
        }
    }
}