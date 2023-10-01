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
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public CreateLeaveRequest_ValidatorDTO(ILeaveRequestRepository repository)
        {
            _leaveRequestRepository = repository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} should be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} should be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveRequestExist = await _leaveRequestRepository.RequestExists(id);
                    return !leaveRequestExist;
                }).WithMessage("{PropertyName} does not exist, [Lambda method return !Exist value]");
        }
    }
}
