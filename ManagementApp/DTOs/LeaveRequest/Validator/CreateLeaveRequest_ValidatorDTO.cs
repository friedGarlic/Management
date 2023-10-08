using FluentValidation;
using Management.Application.Contracts.Persistence;
using Management.Application.DTOs.LeaveRequest.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveRequest.Validator
{
    public class CreateLeaveRequest_ValidatorDTO : AbstractValidator<LeaveRequestDTO>
    {
        private readonly IDataTypeRepository _dataTypeRepo;

        public CreateLeaveRequest_ValidatorDTO(IDataTypeRepository repository)
        {
            _dataTypeRepo = repository;

            Include(new ILeaveRequest_ValidatorDTO(_dataTypeRepo));
        }
    }
}
