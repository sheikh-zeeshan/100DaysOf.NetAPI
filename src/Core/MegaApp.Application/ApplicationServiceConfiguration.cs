using System.Reflection;
using MegaApp.Application.Features.LeaveType.Queries;
using Mapster;

using MegaApp.Application.Models;
using MegaApp.Domain.Entities;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MegaApp.Application.Features.LeaveType.Commands;
using MegaApp.Application.Validators;

using System.Reflection;
using MapsterMapper;
using MegaApp.Application.Features.LeaveAllocation.Commands;
namespace MegaApp.Application;

public static class ApplicationServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        //MAPPER
        MapEntityToDTO.RegisterEntityToModelMappingConfiguration();//services
                                                                   //var typesOfLeaves = _leaveTypeModelObject.Adapt<DTO>();

        var config = new TypeAdapterConfig();
        // Or
        // var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        //MEDIAT R
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //VALIDATOR
        services.AddScoped<IValidator<CreateLeaveTypeCommand>, CreateLeaveTypeCommandValidator>();
        services.AddScoped<IValidator<CreateLeaveAllocationCommand>, CreateLeaveAllocationCommandValidator>();
        services.AddScoped<IValidator<UpdateLeaveAllocationCommand>, UpdateLeaveAllocationCommandValidator>();

        return services;
    }


}

/*
Mapster usage

var destObject = sourceObject.Adapt<Destination>();
sourceObject.Adapt(destObject);


services.AddMapster();
 public Test(IMapper mapper)
{
    var sourceObject = mapper.Adapt<Destination>();
}


*/