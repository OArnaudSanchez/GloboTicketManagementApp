using System;
using System.Collections.Generic;

namespace GloboTIcket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent
{
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryEventDto> Events { get; set; }
    }
}