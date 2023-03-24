﻿using MediatR;
using System;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}