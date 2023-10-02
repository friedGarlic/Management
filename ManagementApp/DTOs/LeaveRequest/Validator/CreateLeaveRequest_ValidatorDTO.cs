using FluentValidation;
using Management.Application.DTOs.LeaveRequest.Process;
using ManagementApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveRequest.Validator
{
    internal class CreateLeaveRequest_ValidatorDTO : AbstractValidator<CreateLeaveRequestDTO>
    {
        private readonly IDataTypeRepository _dataTypeRepo;

        public CreateLeaveRequest_ValidatorDTO(IDataTypeRepository repository)
        {
            _dataTypeRepo = repository;

            Include(new ILeaveRequest_ValidatorDTO(_dataTypeRepo));
        }
    }
}
