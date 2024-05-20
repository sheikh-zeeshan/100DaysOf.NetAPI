

using MapsterMapper;

using MediatR;

using MegaApp.Application.Features.LeaveType.Queries;
using MegaApp.Application.Interfaces.Logging;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveAllocation.Queries;


public class LeaveAllocationDTO
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public LeaveTypeDTO LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }

    public int EmployeeId { get; set; }
}
public class GetLeaveAllocationQuery : IRequest<List<LeaveAllocationDTO>> { }


public class GetLeaveAllocationHandler : IRequestHandler<GetLeaveAllocationQuery, List<LeaveAllocationDTO>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepo;
    private readonly IAppLogger<GetLeaveAllocationHandler> _appLogger;

    public GetLeaveAllocationHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepo, IAppLogger<GetLeaveAllocationHandler> appLogger)
    {
        this._mapper = mapper;
        this._leaveAllocationRepo = leaveAllocationRepo;
        _appLogger = appLogger;
    }

    public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationQuery request, CancellationToken cancellationToken)
    {
        var allocationsFromDB = await _leaveAllocationRepo.GetAllAsync(cancellationToken);

        var leaveAllocationDTO = _mapper.Map<List<LeaveAllocationDTO>>(allocationsFromDB);

        return leaveAllocationDTO;

    }
}