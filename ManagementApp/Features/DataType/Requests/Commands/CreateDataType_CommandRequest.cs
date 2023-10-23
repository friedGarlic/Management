using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.DataType.Process;
using MediatR;

namespace Management.Application.Features.DataType.Requests.Commands
{
    public class CreateDataType_CommandRequest : IRequest<int>
    {
        public CreateDataTypeDTO CreateDataTypeDTO { get; set; }
        public DataTypeDTO DataTypeDTO { get; set; }
    }
}
