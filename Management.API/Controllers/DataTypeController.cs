using Microsoft.AspNetCore.Mvc;
using MediatR;
using Management.Application.DTOs.DataType.Process;
using Management.Application.Features.LeaveRequest.Request.Queries;
using Management.Application.Features.DataType.Handlers.Commands;
using Management.Application.Features.DataType.Requests.Commands;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DataTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DataTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] //Get Api/Controller
        public async Task<ActionResult<List<DataTypeDTO>>> Get()
        {
            var dataType = await _mediator.Send(new GetLeaveRequest_ListRequest());
            return Ok(dataType);
        }

        [HttpGet("{Id}")] //Get Api/controller/id
        public async Task<ActionResult> Get(int id) {

            var dataType = await _mediator.Send(new GetLeaveRequest_ListRequest { Id = id});
            return Ok(dataType);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateDataTypeDTO createDataType)
        {
            var command = new CreateDataType_CommandRequest { CreateDataTypeDTO = createDataType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Put([FromBody] DataTypeDTO dataTypeDTO)
        {
            var updateCommand = new UpdateDataType_CommandRequest { DataTypeDTO = dataTypeDTO };
            await _mediator.Send(updateCommand);
            return NoContent(); // as updatecommand handler returns Unit.value which is NULL or VOID;
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCommand = new DeleteDataType_CommandRequest { Id = id };
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
