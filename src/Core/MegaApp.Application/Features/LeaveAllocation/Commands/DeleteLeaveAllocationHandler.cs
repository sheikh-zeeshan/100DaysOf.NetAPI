

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.LeaveAllocation.Commands;

public class DeleteLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
}

public class DeleteLeaveAllocationCommadHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _repository;

    public DeleteLeaveAllocationCommadHandler(ILeaveAllocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocationToDelete = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (leaveAllocationToDelete == null) throw new NotFoundException(nameof(LeaveAllocation), request.Id);

        await _repository.DeleteAsync(leaveAllocationToDelete, cancellationToken);

        return Unit.Value;

    }
}