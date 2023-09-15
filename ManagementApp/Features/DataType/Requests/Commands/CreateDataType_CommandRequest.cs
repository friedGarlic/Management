﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.DataType;
using MediatR;

namespace Management.Application.Features.DataType.Requests.Commands
{
    internal class CreateDataType_CommandRequest : IRequest<int>
    {
        public DataTypeDTO DataTypeDTO { get; set; }
    }
}
