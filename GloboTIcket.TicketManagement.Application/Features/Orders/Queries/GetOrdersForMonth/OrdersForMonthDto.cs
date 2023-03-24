﻿using System;

namespace GloboTIcket.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class OrdersForMonthDto
    {
        public Guid Id { get; set; }

        public int OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }
    }
}