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


namespace MegaApp.Application;

public static class ApplicationServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        MapEntityToDTO.RegisterEntityToModelMappingConfiguration();//services
                                                                   //var typesOfLeaves = _leaveTypeModelObject.Adapt<DTO>();

        services.AddScoped<IValidator<CreateLeaveTypeCommand>, CreateLeaveTypeCommandValidator>();

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