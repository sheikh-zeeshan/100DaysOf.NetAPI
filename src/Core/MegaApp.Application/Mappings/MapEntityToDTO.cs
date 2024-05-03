
using System.Reflection;
using Mapster;
using MegaApp.Application.Features.LeaveType.Queries;
using MegaApp.Domain.Entities;

namespace MegaApp.Application;
public static class MapEntityToDTO
{

    public static void RegisterEntityToModelMappingConfiguration()
    {
        MapLeaveTypeToLeaveTypeDTO();
        MapLeaveTypeToLeaveTypeDetailsDTO();

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

}