using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using GloboTIcket.TicketManagement.Domain.Entities;
using GloboTIcket.TicketManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Persistance.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool IncludePassedEvents)
        {
            var categories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (IncludePassedEvents)
            {
                categories.ForEach(x => x.Events.ToList().RemoveAll(x => x.Date < DateTime.Today));
            }
            return categories;
        }
    }
}