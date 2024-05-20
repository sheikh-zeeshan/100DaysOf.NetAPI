

using Mapster;

using MapsterMapper;

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveRequest.Commands;

public class UpdateLeaveRequestCommand : IRequest<Unit>
{

    public int LeaveRequestId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public DateTime DateRequested { get; set; }
    public string? RequestComments { get; set; }

    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public int LeaveTypeId { get; set; }

    public int RequestingEmployeeId { get; set; }

}

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _repo;

    //readonly IValidator<UpdateLeaveAllocationCommand> _validator;
    public UpdateLeaveRequestCommandHandler(
        IMapper mapper,
        ILeaveRequestRepository repo
    //   ILeaveAllocationRepository leaveAllocationRepository,
    //  IValidator<UpdateLeaveAllocationCommand> validator

    )
    {
        _mapper = mapper;
        this._repo = repo;
    }


    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _repo.GetByIdAsync(request.LeaveTypeId, cancellationToken);

        if (leaveRequest is null)
            throw new NotFoundException(nameof(LeaveRequest), request.LeaveTypeId);

        leaveRequest = request.Adapt<Domain.Entities.LeaveRequest>();

        try
        {
            await _repo.UpdateAsync(leaveRequest, cancellationToken);
        }
        catch (Exception ex)
        {

        }
        return Unit.Value;

    }



}