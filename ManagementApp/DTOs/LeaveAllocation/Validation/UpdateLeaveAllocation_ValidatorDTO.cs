using FluentValidation;
using Management.Application.DTOs.LeaveAllocation.Process;
using ManagementApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveAllocation.Validation
{
    public class UpdateLeaveAllocation_ValidatorDTO : AbstractValidator<LeaveAllocationDTO>
    {
        private readonly IDataTypeRepository repos;
        public UpdateLeaveAllocation_ValidatorDTO(IDataTypeRepository _repos)
        {
            repos = _repos;

            Include(new ILeaveAllocation_ValidatorDTO(repos));
        }
    }
}
