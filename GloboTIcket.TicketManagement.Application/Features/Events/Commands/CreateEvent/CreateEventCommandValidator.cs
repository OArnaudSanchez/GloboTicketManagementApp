using FluentValidation;
using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is Required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("{PropertyName} is Required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(x => x)
                .MustAsync(EventNameAndDateUnique) //With MustAsync we can create custom validation or more complex validation
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("{PropertyName} is Required.")
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand eventData, CancellationToken cancellationToken)
        {
            return !(await _eventRepository.IsEventNameAndDateUnique(eventData.Name, eventData.Date));
        }
    }
}