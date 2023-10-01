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
    internal class CreateLeaveAllocation_ValidatorDTO : AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly IDataTypeRepository _repository;

        public CreateLeaveAllocation_ValidatorDTO(IDataTypeRepository repository)
        {
            _repository = repository;

            Include(new ILeaveAllocation_ValidatorDTO(_repository));
        }
    }
}
