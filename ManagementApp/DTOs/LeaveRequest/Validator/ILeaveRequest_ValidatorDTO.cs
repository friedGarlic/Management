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
    internal class ILeaveRequest_ValidatorDTO : AbstractValidator<LeaveRequestDTO>
    {
        private readonly IDataTypeRepository _dataTypeRepository;

        public ILeaveRequest_ValidatorDTO(IDataTypeRepository _repository)
        {
            _dataTypeRepository = _repository;

            RuleFor(p => p.StartDate)
                    .LessThan(p => p.EndDate).WithMessage("{PropertyName} should be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                    .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} should be after {ComparisonValue}");

            RuleFor(p => p.LeaveType)
                    .NotEmpty().WithMessage("{PropertyName} can't be null");

            RuleFor(p => p.LeaveTypeId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var leaveRequestExist = await _dataTypeRepository.RequestExists(id);
                        return !leaveRequestExist;
                    }).WithMessage("{PropertyName} does not exist, [Lambda method return !Exist value]");
        }
    }
}
