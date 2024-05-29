using System.Xml;

using Mapster;

using MapsterMapper;

using MediatR;

using MegaApp.Application.Interfaces.Persistance;

namespace MegaApp.Application.Features.Tenant.Commands;

public class CreateTenantCommand : IRequest<int>
{
    public int TenantId { get; set; }

    public string Details { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public string Name { get; set; }

    public int AddressId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }

    public string City { get; set; }
    public string state { get; set; }
    public string Zip { get; set; }

    public List<TenantHostelDTO> Hostels { get; set; }

    public int UserId { get; set; }
}

public class TenantHostelDTO
{

    public string Name { get; set; }


    public bool IsActive { get; set; }
    //employee
    //rooms
    //tags

    public string Tags { get; set; }

}

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, int>
{
    private readonly ITenantRepository _repo;
    private readonly IMapper _mapper;
    public CreateTenantCommandHandler(IMapper mapper, ITenantRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<int> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {

        //The Adapt method is more versatile and commonly used. It creates a new instance of the destination type and maps the properties from the source object to this new instance
        var tenant = request.Adapt<Domain.Entities.Tenant>();

        //Mapper is casuing issues some fields remain null
        //The Map method is used to perform mapping between two objects where you already have both instances created
        //var t = _mapper.Map<Domain.Entities.Tenant>(request); 

        await _repo.InsertAsync(tenant, cancellationToken);

        return tenant.Id;
    }


}

