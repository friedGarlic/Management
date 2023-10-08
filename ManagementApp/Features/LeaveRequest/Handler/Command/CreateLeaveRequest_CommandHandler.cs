using AutoMapper;
using Management.Application.DTOs.LeaveRequest.Validator;
using Management.Application.Features.LeaveRequest.Request.Command;
using MediatR;
using Management.Application.Exceptions;
using Management.Application.Responses;
using Management.Application.Contracts.Persistence;

namespace Management.Application.Features.LeaveRequest.Handler.Command
{
    public class CreateLeaveRequest_CommandHandler : IRequestHandler<CreateLeaveRequest_CommandRequest, BaseCommandResponse>
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

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequest_CommandRequest commandRequest, CancellationToken token)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequest_ValidatorDTO(_dataTypeRepository);
            var validatorResult = await validator.ValidateAsync(commandRequest.LeaveRequestDTO);

            if (validatorResult.IsValid == false)
            {
                response.Message = "Creation of Leave Request Failed";
                response.Success = false;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<Management.LeaveRequest>(commandRequest);

            leaveRequest = await _repository.Add(leaveRequest);

            response.Message = "Successfully created Leave Request";
            response.Success = true;
            response.Id = leaveRequest.Id;

            return response;
        }
    }
}
