﻿using FluentValidation;
using Management.Application.Contracts.Persistence;
using Management.Application.DTOs.LeaveRequest.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveRequest.Validator
{
    public class UpdateLeaveRequest_ValidatorDTO : AbstractValidator<LeaveRequestDTO>
    {
        private readonly IDataTypeRepository _dataTypeRepository;

        public UpdateLeaveRequest_ValidatorDTO(IDataTypeRepository dataTypeRepository)
        {
            _dataTypeRepository = dataTypeRepository;

            Include(new ILeaveRequest_ValidatorDTO(_dataTypeRepository));
        }
    }
}
