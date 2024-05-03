

using FluentValidation;

using MegaApp.Application.Features.LeaveType.Commands;
using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Entities;

namespace MegaApp.Application.Validators;


public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _repository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository repository)
    {
        _repository = repository;

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage($"Name is required")
            .NotNull()
            .MaximumLength(70)
            .WithMessage("Length should be greater than 70 chars.");


        // RuleFor(p => p.DefaultDays)
        //     .GreaterThan(100)
        //     .WithMessage($"Cannot exceed 100")
        //     .LessThan(1)
        //     .WithMessage("Cannot less than 1");

        RuleFor(p => p.DefaultDays)
    .LessThan(100)
    .WithMessage("{PropertyName} cannot exceed 100")
    .GreaterThan(1)
    .WithMessage("{PropertyName} cannot be less than 1");


        RuleFor(q => q)
        .MustAsync(LeaveTypeNameUnique)
        .WithMessage("Leave type already exists.");

    }

    private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return await _repository.IsLeaveTypeUnique(command.Name);
    }
}