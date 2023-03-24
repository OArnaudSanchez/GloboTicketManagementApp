using AutoMapper;
using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class GetOrdersForMonthQueryHandler : IRequestHandler<GetOrdersForMonthQuery, PagedOrdersForMonthVm>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public GetOrdersForMonthQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<PagedOrdersForMonthVm> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
            var ordersDto = _mapper.Map<List<OrdersForMonthDto>>(orders);
            var count = await _orderRepository.GetTotalCountOfOrdersForMonth(request.Date);
            return new PagedOrdersForMonthVm { Count = count, OrdersForMonth = ordersDto, Page = request.Page, Size = request.Size };
        }
    }
}