
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using MegaApp.Application.Features.LeaveRequest.Commands;
using MegaApp.Application.Features.LeaveRequest.Queries;

using Microsoft.AspNetCore.Mvc;
//using MegaApp.HostelManagementAPI.Models;

namespace MegaApp.HostelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // TODO: Your code here
            var data = await _mediator.Send(new GetLeaveRequestQuery());

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            // TODO: Your code here
            var data = await _mediator.Send(new GetLeaveRequestDetailQuery(id));

            return Ok(data);

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLeaveRequestCommand model)
        {
            var response = await _mediator.Send(model);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(int id, CreateLeaveRequestCommand model)
        {
            var response = await _mediator.Send(model);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}