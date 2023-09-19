﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace Management.Application.Features.LeaveAllocation.Request.Command
{
    internal class CreateLeaveAllocation_CommandRequest : IRequest<int>
    {
        public LeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}