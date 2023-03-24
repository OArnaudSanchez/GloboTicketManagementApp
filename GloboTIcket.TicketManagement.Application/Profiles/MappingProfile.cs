using AutoMapper;
using GloboTIcket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTIcket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTIcket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using GloboTIcket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTIcket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTIcket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTIcket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using GloboTIcket.TicketManagement.Application.Features.Events.Queries.List;
using GloboTIcket.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
using GloboTIcket.TicketManagement.Domain.Entities;

namespace GloboTIcket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}