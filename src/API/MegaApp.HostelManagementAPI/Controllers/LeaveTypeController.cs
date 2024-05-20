
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using MegaApp.Application.Features.LeaveType.Commands;
using MegaApp.Application.Features.LeaveType.Queries;

using Microsoft.AspNetCore.Mvc;
//using MegaApp.HostelManagementAPI.Models;

namespace MegaApp.HostelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeQuery());
            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTModelById(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return Ok(leaveType);

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post(CreateLeaveTypeCommand model)
        {
            var response = await _mediator.Send(model);
            return CreatedAtAction(nameof(Get), new { Id = response });


        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(int id, CreateLeaveTypeCommand model)
        {
            var response = await _mediator.Send(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
            return NoContent();
        }


    }
}