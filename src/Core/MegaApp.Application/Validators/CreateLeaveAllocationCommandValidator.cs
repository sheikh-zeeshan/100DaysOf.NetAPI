


using System.Data;

using FluentValidation;

using MegaApp.Application.Features.LeaveAllocation.Commands;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Validators;

public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.NumberOfDays)
    .LessThan(100)
    .WithMessage("{PropertyName} cannot exceed 100")
    .GreaterThan(1)
    .WithMessage("{PropertyName} cannot be less than 1");

        RuleFor(p => p.LeaveTypeId)
               .GreaterThan(0)
               .MustAsync(LeaveTypeMustExist)
               .WithMessage("{PropertyName} does not exist.");


    }
    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id, arg2);
        return leaveType != null;
    }

}