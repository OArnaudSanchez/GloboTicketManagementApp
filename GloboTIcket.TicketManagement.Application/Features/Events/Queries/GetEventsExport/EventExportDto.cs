﻿using System;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class EventExportDto
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}