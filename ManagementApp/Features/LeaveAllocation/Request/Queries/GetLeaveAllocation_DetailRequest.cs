﻿using Management.Application.DTOs.LeaveAllocation.Process;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Request.Queries
{
    public class GetLeaveAllocation_DetailRequest : IRequest<LeaveAllocationDTO>
    {
        public int Id { get; set; }
    }
}
