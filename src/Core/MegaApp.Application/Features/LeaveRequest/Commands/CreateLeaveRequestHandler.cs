

using System.Buffers.Text;

using Mapster;

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Logging;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveRequest.Commands;

public class CreateLeaveRequestCommand : IRequest<int>
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

public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<CreateLeaveRequestHandler> _appLogger;
    public CreateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IAppLogger<CreateLeaveRequestHandler> appLogger)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _appLogger = appLogger;
    }
    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        //var leaveReqiest = request.Adapt<LeaveRequest>

        var leaveRequest = request.Adapt<Domain.Entities.LeaveRequest>();
        leaveRequest.RowVersion = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
        //System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString())

        // var leaveRequest = new Domain.Entities.LeaveRequest
        // {
        //     RequestingEmployeeId = request.RequestingEmployeeId,
        //     StartDate = request.StartDate,
        //     EndDate = request.EndDate,
        //     DateRequested = request.DateRequested,
        //     RequestComments = request.RequestComments,
        //     Approved = request.Approved,
        //     Cancelled = request.Cancelled,
        //     LeaveTypeId = request.LeaveTypeId,
        //     RowVersion = BitConverter.GetBytes(DateTime.UtcNow.ToBinary())
        //     //  System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString())
        //     // new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 }

        // };


        await _leaveRequestRepository.InsertAsync(leaveRequest, cancellationToken);
        return leaveRequest.Id;
    }


}