using FluentValidation;
using Management.Application.DTOs.LeaveAllocation.Process;
using ManagementApp.Contracts;

namespace Management.Application.DTOs.LeaveAllocation.Validation
{
    public class CreateLeaveAllocation_ValidatorDTO : AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly IDataTypeRepository _repository;

        public CreateLeaveAllocation_ValidatorDTO(IDataTypeRepository repository)
        {
            _repository = repository;

            Include(new ILeaveAllocation_ValidatorDTO(_repository));
        }
    }
}
