using AutoMapper;
using Management.Application.DTOs.LeaveRequest.Validator;
using Management.Application.Features.LeaveRequest.Request.Command;
using ManagementApp.Contracts;
using MediatR;
using Management.Application.Exceptions;

namespace Management.Application.Features.LeaveRequest.Handler.Command
{
    public class UpdateLeaveRequest_CommandHandler : IRequestHandler<UpdateLeaveRequest_CommandRequest, Unit>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IDataTypeRepository _dataTypeRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveRequest_CommandHandler(ILeaveRequestRepository repository, Mapper mapper, IDataTypeRepository dataTypeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _dataTypeRepository = dataTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequest_CommandRequest commandRequest, CancellationToken token)
        {
            var updateValidator = new UpdateLeaveRequest_ValidatorDTO(_dataTypeRepository);
            var validatorResult = await updateValidator.ValidateAsync(commandRequest.LeaveRequestDTO);

            if (validatorResult.IsValid == false)
            {
                throw new ValidationException(validatorResult);
            }

            var leaveRequest = await _repository.Get(commandRequest.LeaveRequestDTO.Id);

            if (commandRequest.LeaveRequestDTO != null)
            {
                _mapper.Map(commandRequest.LeaveRequestDTO, leaveRequest);

                await _repository.Update(leaveRequest);
            }
            if (commandRequest.ChangeLeaveRequestApprovalDTO != null)
            {
                await _repository.ChangeLeaveRequestApproval(leaveRequest, commandRequest.ChangeLeaveRequestApprovalDTO.IsApproved);
            }

            return Unit.Value;
        }
    }
}
