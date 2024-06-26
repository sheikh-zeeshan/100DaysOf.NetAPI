
using System.Reflection;

using Mapster;

using MegaApp.Application.Features.LeaveAllocation.Queries;
using MegaApp.Application.Features.LeaveRequest.Queries;
using MegaApp.Application.Features.LeaveType.Queries;
using MegaApp.Application.Features.Queries;
using MegaApp.Application.Features.Tenant.Commands;
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
        MapTenantQueryAndAddressDTO();

        MapTenantAndCreateCommandDTO();

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        TypeAdapterConfig.GlobalSettings.Compile(true);
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

    static void MapTenantQueryAndAddressDTO()
    {
        //     TypeAdapterConfig<Dto, Poco>.NewConfig()
        // .Map(poco => poco, dto => dto.SubDto);

        var config = TypeAdapterConfig<Tenant, TenentQueryDTO>
         .NewConfig()
         .Map(dest => dest.Id, src => src.Id)
         .Map(dest => dest.Name, src => src.TenantName)
         .Map(dest => dest.Description, src => src.Description)
         .Map(dest => dest.Email, src => src.Email)
         .Map(dest => dest.Phone, src => src.Phone)
         //Address
         .Map(dest => dest.AddressLine1, src => src.Address.AddressLine1)
         .Map(dest => dest.AddressLine2, src => "==Missing==")
         .Map(dest => dest.City, src => src.Address.City)
         .Map(dest => dest.State, src => src.Address.State)
         .Map(dest => dest.Zip, src => src.Address.ZipCode)
         .Map(dest => dest.AddressId, src => src.Address.Id)
         //UserName
         .Map(dest => dest.UserId, src => src.AppUser.Id)

         //.Map(dest => dest.Tags, src => src.PostTags.Adapt<TagDto>()).Unflattening(true)
         .TwoWays();


        /*
        var config = TypeAdapterConfig<(DTO1, DTO2, DTO3), POCO>.NewConfig()
                   .Map(dest => dest.Age, src => src.Item1.Age)
                   .Map(dest => dest.ID, src => src.Item2.ID)
                   .Map(dest => dest.Name, src => src.Item3.Name);

        */
    }
    static void MapTenantAndCreateCommandDTO()
    {
        TypeAdapterConfig<CreateTenantCommand, Tenant>.NewConfig()
            .Map(dest => dest.Description, src => src.Details)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.TenantName, src => src.Name)
            .Map(dest => dest.Address, src => src.Adapt<Address>())
            .Map(dest => dest.TenantHostels, src => src.Hostels.Adapt<List<TenantHostel>>())
                ;

        TypeAdapterConfig<CreateTenantCommand, Address>.NewConfig()
            .Map(dest => dest.AddressLine1, src => src.AddressLine1)
            .Map(dest => dest.AddressLine2, src => src.AddressLine2)
            .Map(dest => dest.City, src => src.City)
            .Map(dest => dest.State, src => src.state)
            .Map(dest => dest.ZipCode, src => src.Zip);

        TypeAdapterConfig<TenantHostelDTO, TenantHostel>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.IsActive, src => src.IsActive)
        .Map(dest => dest.Tags, src => src.Tags
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.Trim())
                        .ToList()
            )
        //.Map(dest => dest.Tags, src => GetList(src.CommaSeparatedValues<Tag>))
        ;
    }

    // private static List<T> GetList<T>(string commaSeparatedValues)
    // {
    //   return  commaSeparatedValues
    //         .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
    //         .Select(s => s.Trim())
    //         .ToList();
    // }
}
