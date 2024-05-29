
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;

using Mapster;

using MapsterMapper;

using MediatR;

using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Entities;

namespace MegaApp.Application.Features.Queries;


public class TenentQueryDTO
{
    public string Description { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public int AddressId { get; set; }
    public int Id { get; set; }
    public int UserId { get; internal set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

public class GetAllTenantQuery : IRequest<List<TenentQueryDTO>> { }
public class GetAllTenantQueryHandler : IRequestHandler<GetAllTenantQuery, List<TenentQueryDTO>>
{

    IMapper _mapper;
    ITenantRepository _repo;
    public GetAllTenantQueryHandler(IMapper mapper, ITenantRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<List<TenentQueryDTO>> Handle(GetAllTenantQuery request, CancellationToken cancellationToken)
    {
        // // // var sqids = new SqidsEncode<int>(new()
        // // // {
        // // //     AssemblyCopyrightAttribute = "mTHiv07",
        // // //     MinLengthAttribute = 7
        // // // });
        // // // ; sqids.Encode(1402)

        //TODO: paging , sorting and filtering should be applied here
        var data = await _repo.GetAllAsync(cancellationToken);

        System.Diagnostics.Debug.WriteLine(data[0].ToString());


        // var signleTenant = data[0].Adapt<TenentQueryDTO>();
        // var listTenants = data.Adapt<List<TenentQueryDTO>>();

        var tenants = data.Adapt<List<TenentQueryDTO>>();

        // var tenants = data.ProjectToType<TenentQueryDTO>().ToList();

        System.Diagnostics.Debug.WriteLine(tenants[0].ToString());

        return tenants;
    }
}

// public class GetTenentQueryDTO
// {
//     public string Name { get; set; }
//     public string Email { get; set; }
//     public string Phone { get; set; }
//     public string Address { get; set; }
//     public string RoomNumber { get; set; }
//     public string RoomType { get; set; }
//     public string RoomRent { get; set; }
//     public string RoomStatus { get; set; }
//     public string RoomDescription { get; set; }
//     public string RoomImage { get; set; }
//     public string RoomFacilities { get; set; }
//     public string RoomCapacity { get; set; }
//     public string RoomSize { get; set; }
//     public string RoomFloor { get; set; }
//     public string RoomCategory { get; set; }
//     public string RoomCreatedOn { get; set; }
//     public string RoomUpdatedOn { get; set; }
//     public string RoomCreatedBy { get; set; }
//     public string RoomUpdatedBy { get; set; }
//     public string RoomDeletedOn { get; set; }
//     public string RoomDeletedBy { get; set; }
//     public string RoomIsDeleted { get; set; }
//     public string RoomIsActive { get; set; }
//     public string RoomIsBooked { get; set; }
//     public string RoomIsOccupied { get; set; }
//     public string RoomIsReserved { get; set; }
//     public string RoomIsAvailable { get; set; }
//     public string RoomIsUnderMaintenance { get; set; }
//     public string RoomIsCleaned { get; set; }
//     public string RoomIsDirty { get; set; }
//     public string RoomIsDamaged { get; set; }
//     public string RoomIsRepaired { get; set; }
//     public string RoomIsRenovated { get; set; }
//     public string RoomIsUpgraded { get; set; }
//     public string RoomIsDowngraded { get; set; }
//     public string RoomIsLocked { get; set; }
//     public string RoomIsUnlocked { get; set; }
//     public string RoomIsBlocked { get; set; }
//     public string RoomIsUnblocked { get; set; }
//     public string RoomIsSealed { get; set; }
//     public string RoomIsUnsealed { get; set; }
//     public string RoomIsApproved { get; set; }
// }


