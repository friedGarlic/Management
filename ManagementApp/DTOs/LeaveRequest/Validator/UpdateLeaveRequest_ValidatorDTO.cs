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
    public class UpdateLeaveRequest_ValidatorDTO : AbstractValidator<UpdateLeaveRequestDTO>
    {
        private readonly IDataTypeRepository _dataTypeRepository;

        public UpdateLeaveRequest_ValidatorDTO(IDataTypeRepository dataTypeRepository)
        {
            _dataTypeRepository = dataTypeRepository;

            Include(new ILeaveRequest_ValidatorDTO(_dataTypeRepository));
        }
    }
}
