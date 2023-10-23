using Management.Application.DTOs.DataType.Process;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.DataType.Requests.Commands
{
    public class DeleteDataType_CommandRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
