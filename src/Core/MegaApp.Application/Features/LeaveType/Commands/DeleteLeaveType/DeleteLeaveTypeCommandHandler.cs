


using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveType.Commands;

public class DeleteLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}


public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _repository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeToDelete = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (leaveTypeToDelete == null) throw new NotFoundException(nameof(LeaveType), request.Id);

        await _repository.DeleteAsync(leaveTypeToDelete, cancellationToken);

        return Unit.Value;
    }
}