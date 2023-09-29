﻿using Management.Application.DTOs.DataType.Process;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.DataType.Requests.Queries
{
    internal class GetDataType_DetailRequest : IRequest<DataTypeDTO>
    {
        public int Id { get; set; }
    }
}
