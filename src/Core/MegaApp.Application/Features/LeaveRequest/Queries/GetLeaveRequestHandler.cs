
using MapsterMapper;

using MediatR;

using MegaApp.Application.Interfaces.Logging;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveRequest.Queries;

public class LeaveRequestDTO
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

public class GetLeaveRequestQuery : IRequest<List<LeaveRequestDTO>> { }

public class GetLeaveRequestQueryHandler : IRequestHandler<GetLeaveRequestQuery, List<LeaveRequestDTO>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepo;
    private readonly IAppLogger<GetLeaveRequestQueryHandler> _appLogger;

    public GetLeaveRequestQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepo, IAppLogger<GetLeaveRequestQueryHandler> appLogger)
    {
        _mapper = mapper;
        _leaveRequestRepo = leaveRequestRepo;
        _appLogger = appLogger ?? throw new NullReferenceException();

    }
    public async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequestQuery request, CancellationToken cancellationToken)
    {
        var data = await _leaveRequestRepo.GetAllAsync(cancellationToken);

        var requestDTO = _mapper.Map<List<LeaveRequestDTO>>(data);

        return requestDTO;
    }
}