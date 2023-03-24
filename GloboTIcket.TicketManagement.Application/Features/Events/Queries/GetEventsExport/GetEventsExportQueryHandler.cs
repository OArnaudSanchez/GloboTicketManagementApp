using AutoMapper;
using GloboTIcket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileVm>
    {
        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;

        private readonly ICsvExporter _csvExporter;

        public GetEventsExportQueryHandler(IEventRepository eventRepository, IMapper mapper, ICsvExporter csvExporter)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _csvExporter = csvExporter;
        }

        public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var events = _mapper.Map<List<EventExportDto>>((await _eventRepository.ListAllAsync()).OrderBy(x => x.Date));
            var fileData = _csvExporter.ExportEventsToCsv(events);
            var eventsDto = new EventExportFileVm
            {
                //This string values shoud not be harcoded here, instead we can use AppSettings.json file
                ContentType = "text/csv",
                Data = fileData,
                EventExportFileName = $"{Guid.NewGuid()}.csv"
            };

            return eventsDto;
        }
    }
}