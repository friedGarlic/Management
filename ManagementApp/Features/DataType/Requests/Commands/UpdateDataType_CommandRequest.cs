using Management.Application.DTOs.DataType.Process;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.DataType.Requests.Commands
{
    internal class UpdateDataType_CommandRequest : IRequest<Unit>
    {
        public DataTypeDTO DataTypeDTO { get; set; }
    }
}
