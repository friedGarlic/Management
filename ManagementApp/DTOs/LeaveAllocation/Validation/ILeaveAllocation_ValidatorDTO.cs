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
    internal class ILeaveAllocation_ValidatorDTO : AbstractValidator<LeaveAllocationDTO>
    {
        private readonly IDataTypeRepository _repository;

        public ILeaveAllocation_ValidatorDTO(IDataTypeRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.NumberOfDays)
                .LessThan(4).WithMessage("{PropertyName} has to be less than {ComparisonValue}")
                .GreaterThan(1).WithMessage("{PropertyName} has to be greater than {ComparisonValue}");

            RuleFor(p => p.DateCreated)
                .NotEmpty().WithMessage("{PropertyName} is empty"); 

            RuleFor(p => p.Period)  
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(p => p.Id)
                .MustAsync(async (id, token) =>
                {
                    var result = await _repository.RequestExists(id);
                    return !result;
                }).WithMessage("{PropertyName} does not exist");

        }
    }
}
