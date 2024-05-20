

using FluentValidation;

using Mapster;

using MapsterMapper;

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveAllocation.Commands;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }

    public int EmployeeId { get; set; }
}
public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    readonly IValidator<UpdateLeaveAllocationCommand> _validator;
    public UpdateLeaveAllocationCommandHandler(
        IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveAllocationRepository leaveAllocationRepository,
        IValidator<UpdateLeaveAllocationCommand> validator

    )
    {
        _mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._leaveAllocationRepository = leaveAllocationRepository;
        _validator = validator;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Allocation", validationResult);

        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id, cancellationToken);

        if (leaveAllocation is null)
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);

        leaveAllocation = request.Adapt<Domain.Entities.LeaveAllocation>();

        try
        {
            await _leaveAllocationRepository.UpdateAsync(leaveAllocation, cancellationToken);
        }
        catch (Exception ex)
        {

        }
        return Unit.Value;
    }
}