using Management.Application.DTOs.LeaveRequest;
using Management.Application.DTOs.LeaveRequest.Process;
using Management.Application.Features.LeaveRequest.Request.Command;
using Management.Application.Features.LeaveRequest.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
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

        [HttpGet] //Get Api/Controller
        public async Task<ActionResult<List<LeaveRequestDTO>>> Get()
        {
            var LeaveRequest = await _mediator.Send(new GetLeaveRequest_ListRequest());
            return Ok(LeaveRequest);
        }

        [HttpGet("{Id}")] //Get Api/controller/id
        public async Task<ActionResult> Get(int id)
        {

            var LeaveRequest = await _mediator.Send(new GetLeaveRequest_ListRequest { Id = id });
            return Ok(LeaveRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDTO createLeaveRequest)
        {
            var command = new CreateLeaveRequest_CommandRequest { CreateLeaveRequestDTO = createLeaveRequest };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Put([FromBody] LeaveRequestDTO LeaveRequestDTO)
        {
            var updateCommand = new UpdateLeaveRequest_CommandRequest { LeaveRequestDTO = LeaveRequestDTO };
            await _mediator.Send(updateCommand);
            return NoContent(); // as updatecommand handler returns Unit.value which is NULL or VOID;
        }

        [HttpPost("changeapproval/{id}")]
        public async Task<ActionResult> ChangeApproval (int id, [FromBody] ChangeLeaveRequestApprovalDTO _changeLeaveRequestDTO)
        {
            var command = new ChangeLeaveRequestApprovalDTO { Id = id, ChangeLeaveRequestDTO = _changeLeaveRequestDTO };
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCommand = new DeleteLeaveRequest_CommandRequest { Id = id };
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
