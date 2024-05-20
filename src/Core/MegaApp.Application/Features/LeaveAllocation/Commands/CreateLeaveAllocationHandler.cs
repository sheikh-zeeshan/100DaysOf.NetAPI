
using FluentValidation;

using Mapster;

using MapsterMapper;

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Logging;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveAllocation.Commands;


public class CreateLeaveAllocationCommand : IRequest<int>
{
    public int NumberOfDays { get; set; }

    public int Period { get; set; }
    public int LeaveTypeId { get; set; }
    public int EmployeeId { get; set; }
}
public class LeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    readonly IMapper _mapper;
    readonly ILeaveAllocationRepository _leaveAllocationRepo;
    readonly IValidator<CreateLeaveAllocationCommand> _validator;
    private readonly IAppLogger<LeaveAllocationCommandHandler> _appLogger;

    public LeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepo
    , IValidator<CreateLeaveAllocationCommand> validator, IAppLogger<LeaveAllocationCommandHandler> appLogger)
    {
        this._mapper = mapper;
        this._leaveAllocationRepo = leaveAllocationRepo;
        _validator = validator;
        _appLogger = appLogger;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validResult.Errors.Any())
        {
            _appLogger.LogWarning("Errors occured");

            throw new BadRequestException("Model is not correct", validResult);
        }

        var leaveType = request.Adapt<Domain.Entities.LeaveAllocation>();
        //call repo method
        await _leaveAllocationRepo.InsertAsync(leaveType, cancellationToken);
        //return record
        return leaveType.Id;
    }
}