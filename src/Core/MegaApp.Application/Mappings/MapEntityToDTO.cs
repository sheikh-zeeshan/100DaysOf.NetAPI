
using System.Reflection;

using Mapster;

using MegaApp.Application.Features.LeaveAllocation.Queries;
using MegaApp.Application.Features.LeaveRequest.Queries;
using MegaApp.Application.Features.LeaveType.Queries;
using MegaApp.Application.Features.Queries;

using MegaApp.Domain.Entities;

namespace MegaApp.Application;
public static class MapEntityToDTO
{

    public static void RegisterEntityToModelMappingConfiguration()
    {
        MapLeaveTypeToLeaveTypeDTO();
        MapLeaveTypeToLeaveTypeDetailsDTO();
        MapLeaveAllocationToDTO();
        MapLeaveRequestDTO();
        MapTenantAndAddressDTO();

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }

    private static void MapLeaveTypeToLeaveTypeDTO() //IServiceCollection services
    {
        TypeAdapterConfig<LeaveType, LeaveTypeDTO>
        .NewConfig()
        //.Map(dest=>dest.Age, src=> DateTime.Now.Year - src.DOb.Value!.Year, srcond=> srcond.DOb.HasValue)
        .Map(dest => dest.Name, src => src.Name)
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.MaxNoOfLeaves, src => src.DefaultDays)
        .Map(dest => dest.FullName, src => $"{src.Name}{(src.Id)}")
        .Map(dest => dest.MaxNoOfLeaves, src => src.DefaultDays);

        TypeAdapterConfig<LeaveType, LeaveTypeDTO>
        .NewConfig()
        .IgnoreNullValues(true)
        .IgnoreIf((src, dest) => src.Id == 2, dest => dest.Id)
        .Ignore(dest => dest.Id!)
        .TwoWays();

        TypeAdapterConfig<LeaveType, LeaveTypeDTO>
        .ForType()
        .BeforeMapping((src, dest) => dest.SayHello())
        .AfterMapping((src, dest) => dest.SayGoodBye());

    }


    private static void MapLeaveTypeToLeaveTypeDetailsDTO()
    {
        TypeAdapterConfig<LeaveType, LeaveTypeDetailsDTO>
               .NewConfig()
               //.Map(dest=>dest.Age, src=> DateTime.Now.Year - src.DOb.Value!.Year, srcond=> srcond.DOb.HasValue)
               .Map(dest => dest.Name, src => src.Name)
               .Map(dest => dest.Id, src => src.Id)
               .Map(dest => dest.MaxNoOfLeaves, src => src.DefaultDays)
               .Map(dest => dest.FullName, src => $"{src.Name}{(src.Id)}")
               .Map(dest => dest.MaxNoOfLeaves, src => src.DefaultDays);

        TypeAdapterConfig<LeaveType, LeaveTypeDetailsDTO>
        .NewConfig()
        .IgnoreNullValues(true)
        .IgnoreIf((src, dest) => src.Id == 2, dest => dest.Id)
        .Ignore(dest => dest.Id!)
        .TwoWays();



    }

    static void MapLeaveAllocationToDTO()
    {
        TypeAdapterConfig<LeaveAllocation, LeaveAllocationDTO>
             .NewConfig()
             //.Map(dest=>dest.Age, src=> DateTime.Now.Year - src.DOb.Value!.Year, srcond=> srcond.DOb.HasValue)
             .Map(dest => dest.Period, src => src.Period)
             .Map(dest => dest.Id, src => src.Id)
             .Map(dest => dest.NumberOfDays, src => src.NumberOfDays)
             .Map(dest => dest.LeaveTypeId, src => src.LeaveTypeId)
             .Map(dest => dest.EmployeeId, src => src.EmployeeId)
             .TwoWays();
    }


    static void MapLeaveRequestDTO()
    {
        TypeAdapterConfig<LeaveRequest, LeaveRequestDTO>
                   .NewConfig()
                   //.Map(dest=>dest.Age, src=> DateTime.Now.Year - src.DOb.Value!.Year, srcond=> srcond.DOb.HasValue)
                   .Map(dest => dest.StartDate, src => src.StartDate)
                   .Map(dest => dest.LeaveRequestId, src => src.Id)
                   .Map(dest => dest.EndDate, src => src.EndDate)
                   .Map(dest => dest.LeaveTypeId, src => src.LeaveTypeId)
                   .Map(dest => dest.DateRequested, src => src.DateRequested)

                    .Map(dest => dest.RequestComments, src => src.RequestComments)
                    .Map(dest => dest.Approved, src => src.Approved)
                    .Map(dest => dest.Cancelled, src => src.Cancelled)
                    .Map(dest => dest.RequestingEmployeeId, src => src.RequestingEmployeeId)
                   .TwoWays();
    }

    static void MapTenantAndAddressDTO()
    {
        //     TypeAdapterConfig<Dto, Poco>.NewConfig()
        // .Map(poco => poco, dto => dto.SubDto);

        TypeAdapterConfig<Tenant, TenentQueryDTO>
        .NewConfig()
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.Name, src => src.TenantName)
        .Map(dest => dest.Email, src => src.Email)
        .Map(dest => dest.Phone, src => src.Phone)

        .Map(dest => dest.AddressLine1, src => src.Address.AddressLine1)
        .Map(dest => dest.AddressLine2, src => "==Missing==")
        .Map(dest => dest.City, src => src.Address.City)
        .Map(dest => dest.State, src => src.Address.State)
        .Map(dest => dest.Zip, src => src.Address.ZipCode)
    .Map(dest => dest.AddressId, src => src.Address.Id)
        //.Map(dest => dest.Tags, src => src.PostTags.Adapt<TagDto>());
        //.Unflattening(true)
        .TwoWays();

        // TypeAdapterConfig<TenentQueryDTO, Tenant>
        //         .NewConfig()
        //         .Map(dest => dest.Id, src => src.Id)
        //         .Map(dest => dest.TenantName, src => src.Name)

        //         .Map(dest => dest.Email, src => src.Email)
        //         .Map(dest => dest.Phone, src => src.Phone)
        //         .Map(dest => dest.Address.AddressLine1, src => src.AddressLine1)
        //         .Map(dest => dest.Address.City, src => src.City)
        //         .TwoWays();
    }
}




