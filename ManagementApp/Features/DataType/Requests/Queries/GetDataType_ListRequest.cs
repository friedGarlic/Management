﻿using Management.Application.DTOs.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.DataType.Requests.Queries
{
    internal class GetDataType_ListRequest : IRequest<List<DataTypeDTO>>
    {
    }
}