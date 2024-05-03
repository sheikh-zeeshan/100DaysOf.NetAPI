



using FluentValidation;

using Mapster;

using MapsterMapper;

using MediatR;

using MegaApp.Application.Exceptions;
using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Application.Validators;

namespace MegaApp.Application.Features.LeaveType.Commands;



public class CreateLeaveTypeCommand : IRequest<int>
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{

    readonly IMapper _mapper;
    readonly ILeaveTypeRepository _leaveTypeRepo;
    readonly IValidator<CreateLeaveTypeCommand> _validator;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IValidator<CreateLeaveTypeCommand> validator)
    {
        this._mapper = mapper;
        this._leaveTypeRepo = leaveTypeRepository;
        _validator = validator;

    }




    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {

        // var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepo);
        var validResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validResult.Errors.Any())
        {
            throw new BadRequestException("Model is not correct", validResult);
        }
        //balidate incoming data
        //convert DTO to entity

        var leaveType = request.Adapt<Domain.Entities.LeaveType>();
        //call repo method
        await _leaveTypeRepo.InsertAsync(leaveType, cancellationToken);
        //return record
        return leaveType.Id;
    }
}