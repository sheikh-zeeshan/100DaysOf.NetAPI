
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using MegaApp.Application.Features.Queries;
using MegaApp.Application.Features.Tenant.Commands;

using Microsoft.AspNetCore.Mvc;
//using MegaApp.HostelManagementAPI.Models;

namespace MegaApp.HostelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {

        private readonly IMediator _mediator;
        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/GetAllTenents")]
        public async Task<IActionResult> GetAllTenents()
        {

            //return RedirectToAction()
            //return RedirectToRoute
            var data = await _mediator.Send(new GetAllTenantQuery());

            return Ok(data);
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post(CreateTenantCommand model)
        {
            var response = await _mediator.Send(model);
            return Ok();
        }
    }
}