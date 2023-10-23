using Management.Application.DTOs.LeaveAllocation.Process;
using Management.Application.Features.LeaveAllocation.Request.Command;
using Management.Application.Features.LeaveAllocation.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
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

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var get = await _mediator.Send(new GetLeaveAllocation_DetailRequest {Id = id});
            return Ok(get);
        }

        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get()
        {
            var get = await _mediator.Send(new GetLeaveAllocation_ListRequest());
            return Ok(get);
        }

        public async Task<ActionResult> Put(int id, [FromBody] LeaveAllocationDTO leaveAllocationDTO)
        {
            var leaveAlloc = new CreateLeaveAllocation_CommandRequest { LeaveAllocationDTO = leaveAllocationDTO };
            var command = await _mediator.Send(leaveAlloc);
            return Ok(command);
        }

        public async Task<ActionResult> Post(int id, [FromBody] CreateLeaveAllocationDTO leaveAllocationDTO)
        {
            var leaveAlloc = new CreateLeaveAllocation_CommandRequest { CreateLeaveAllocationDTO = leaveAllocationDTO };
            var command = await _mediator.Send(leaveAlloc);
            return Ok(command);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var command = await _mediator.Send(new DeleteLeaveAllocation_CommandRequest { Id = id });
            return NoContent();
        }
    }
}
