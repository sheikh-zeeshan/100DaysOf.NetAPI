
using System.Dynamic;

using MapsterMapper;

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Logging;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveAllocation.Queries;

public record GetLeaveAllocationDetailQuery(int id) : IRequest<LeaveAllocationDTO> { }

public class GetLeaveAllocationDetailHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDTO>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepo;
    private readonly IAppLogger<GetLeaveAllocationDetailHandler> _appLogger;

    public GetLeaveAllocationDetailHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepo, IAppLogger<GetLeaveAllocationDetailHandler> appLogger)
    {
        this._mapper = mapper;
        this._leaveAllocationRepo = leaveAllocationRepo;
        _appLogger = appLogger;
    }

    public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
    {
        var allocationsFromDB = await _leaveAllocationRepo.GetLeaveAllocationWithDetails(request.id) ?? throw new NotFoundException(nameof(LeaveAllocation), request.id);

        var leaveAllocation = _mapper.Map<LeaveAllocationDTO>(allocationsFromDB);

        return leaveAllocation;
    }
}