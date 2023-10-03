using AutoMapper;
using Management.Application.DTOs.LeaveRequest.Validator;
using Management.Application.Features.LeaveRequest.Request.Command;
using ManagementApp.Contracts;
using MediatR;
using Management.Application.Exceptions;

namespace Management.Application.Features.LeaveRequest.Handler.Command
{
    public class CreateLeaveRequest_CommandHandler : IRequestHandler<CreateLeaveRequest_CommandRequest, int>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IDataTypeRepository _dataTypeRepository;
        private readonly Mapper _mapper;

        public CreateLeaveRequest_CommandHandler(ILeaveRequestRepository repository, 
            IDataTypeRepository dataTypeRepository, Mapper mapper)
        {
            _repository = repository;
            _dataTypeRepository = dataTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveRequest_CommandRequest commandRequest, CancellationToken token)
        {
            var validator = new CreateLeaveRequest_ValidatorDTO(_dataTypeRepository);
            var validatorResult = await validator.ValidateAsync(commandRequest.LeaveRequestDTO);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);

            var leaveRequest = _mapper.Map<Management.LeaveRequest>(commandRequest);

            leaveRequest = await _repository.Add(leaveRequest);
            
            return leaveRequest.Id;
        }
    }
}
