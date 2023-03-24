using GloboTIcket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTIcket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTIcket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var categories = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(categories);
        }

        [HttpGet("allWithEvents", Name = "GetCategoriesWithEvents")] //Name should be equal to nameof(method)
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            var categories = await _mediator.Send(new GetCategoriesListWithEventsQuery { IncludeHistory = includeHistory });
            return Ok(categories);
        }

        [HttpPost(Name = nameof(CreateCategory))]
        public async Task<ActionResult<CreateCategoryCommand>> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            //!!!This HttpPost method should return 201 Created instead of 200 Ok
            return Ok(response);
        }
    }
}