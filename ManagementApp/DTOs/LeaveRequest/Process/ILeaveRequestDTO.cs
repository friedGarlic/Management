﻿using Management.Application.DTOs.DataType.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveRequest.Process
{
    internal interface ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }

        public DataTypeDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; } // if sick leave, vacation , etc..

        public bool? IsApproved { get; set; }
        public bool IsDeclined { get; set; }
    }
}
