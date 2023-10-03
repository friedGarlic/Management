using FluentValidation;
using Management.Application.DTOs.LeaveAllocation.Process;
using ManagementApp.Contracts;

namespace Management.Application.DTOs.LeaveAllocation.Validation
{
    //TODO REMINDER this is LeaveAllocationDTO field parameter not CreateLeaveAllocationDTO
    public class CreateLeaveAllocation_ValidatorDTO : AbstractValidator<LeaveAllocationDTO>
    {
        private readonly IDataTypeRepository _repository;

        public CreateLeaveAllocation_ValidatorDTO(IDataTypeRepository repository)
        {
            _repository = repository;
            ILeaveAllocation_ValidatorDTO validator = new ILeaveAllocation_ValidatorDTO(_repository);

            Include(validator);
        }
    }
}
