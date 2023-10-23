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

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get()
        {
            var get = await _mediator.Send(new GetLeaveAllocation_ListRequest());
            return Ok(get);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LeaveAllocationDTO leaveAllocationDTO)
        {
            var leaveAlloc = new UpdateLeaveAllocation_CommandRequest { LeaveAllocationDTO  = leaveAllocationDTO };
            var command = await _mediator.Send(leaveAlloc);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDTO leaveAllocationDTO)
        {
            var leaveAlloc = new CreateLeaveAllocation_CommandRequest { CreateLeaveAllocationDTO = leaveAllocationDTO };
            var command = await _mediator.Send(leaveAlloc);
            return Ok(command);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocation_CommandRequest { Id = id });
            return NoContent();
        }
    }
}
