
using MapsterMapper;

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveType.Queries;

public class LeaveTypeDetailsDTO
{
    public string Name { get; set; }

    public string FullName { get; set; }
    public int MaxNoOfLeaves { get; set; }

    public int Id { get; set; }

}



public record GetLeaveTypeDetailsQuery(int id) : IRequest<LeaveTypeDetailsDTO>;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDTO>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepo;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepo = leaveTypeRepository;
    }

    public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        //TODO: throw exception of send HTTP status code

        //query DB
        var leaveTypeFromDB = await _leaveTypeRepo.GetByIdAsync(request.id, cancellationToken) ?? throw new NotFoundException(nameof(LeaveType), request.id);
        //convert entity to DTO
        var leaveTypeDTO = _mapper.Map<LeaveTypeDetailsDTO>(leaveTypeFromDB);
        //return dto
        return leaveTypeDTO;
    }
}