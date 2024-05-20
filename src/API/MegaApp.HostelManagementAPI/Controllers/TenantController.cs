
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using MegaApp.Application.Features.Queries;

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


    }
}