

using MediatR;

using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveRequest.Commands;

public class DeleteLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _repository;

    public DeleteLeaveRequestHandler(ILeaveRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var dataById = await _repository.GetByIdAsync(request.Id, cancellationToken);

        await _repository.DeleteAsync(dataById, cancellationToken);

        return Unit.Value;
    }
}