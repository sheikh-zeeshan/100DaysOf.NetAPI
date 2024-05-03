

using MapsterMapper;

using MediatR;

using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveType.Queries;

public class LeaveTypeDTO
{
    public string Name { get; set; }

    public string FullName { get; set; }
    public int MaxNoOfLeaves { get; set; }

    public int Id { get; set; }

    public void SayHello() { }
    public void SayGoodBye() { }

}

public record GetLeaveTypeQuery : IRequest<List<LeaveTypeDTO>>;

public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDTO>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepo;

    public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepo = leaveTypeRepository;
    }
    public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
    {

        //query DB
        var leaveTypesFromDB = await _leaveTypeRepo.GetAllAsync(cancellationToken);
        //convert entity to DTO
        var leaveTypeDTO = _mapper.Map<List<LeaveTypeDTO>>(leaveTypesFromDB);
        //return dto
        return leaveTypeDTO;
    }
}