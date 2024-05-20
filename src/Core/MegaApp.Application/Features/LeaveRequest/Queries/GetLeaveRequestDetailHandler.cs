

using MapsterMapper;

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Logging;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveRequest.Queries;


public record GetLeaveRequestDetailQuery(int id) : IRequest<LeaveRequestDTO> { }

public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDTO>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepo;
    private readonly IAppLogger<GetLeaveRequestDetailQueryHandler> _appLogger;

    public GetLeaveRequestDetailQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepo, IAppLogger<GetLeaveRequestDetailQueryHandler> appLogger)
    {
        this._mapper = mapper;
        this._leaveRequestRepo = leaveRequestRepo;
        _appLogger = appLogger;
    }

    public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
    {
        var data = await _leaveRequestRepo.GetLeaveRequestWithDetails(request.id) ?? throw new NotFoundException(nameof(LeaveRequest), request.id);

        var dtoData = _mapper.Map<LeaveRequestDTO>(data);

        return dtoData;
    }
}

