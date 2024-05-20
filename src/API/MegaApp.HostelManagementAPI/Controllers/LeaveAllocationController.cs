
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using MegaApp.Application.Features.LeaveAllocation.Commands;
using MegaApp.Application.Features.LeaveAllocation.Queries;

using Microsoft.AspNetCore.Mvc;
//using MegaApp.HostelManagementAPI.Models;

namespace MegaApp.HostelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _mediator.Send(new GetLeaveAllocationQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _mediator.Send(new GetLeaveAllocationDetailQuery(id));

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLeaveAllocationCommand model)
        {
            var response = await _mediator.Send(model);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(UpdateLeaveAllocationCommand model)
        {
            var response = await _mediator.Send(model);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTModelById(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return NoContent();
        }
    }
}