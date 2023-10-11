using AutoMapper;
using Management.Application.DTOs.LeaveRequest.Validator;
using Management.Application.Features.LeaveRequest.Request.Command;
using MediatR;
using Management.Application.Exceptions;
using Management.Application.Responses;
using Management.Application.Contracts.Persistence;
using Management.Application.Contracts.Infrastructure;
using Management.Application.Model;

namespace Management.Application.Features.LeaveRequest.Handler.Command
{
    public class CreateLeaveRequest_CommandHandler : IRequestHandler<CreateLeaveRequest_CommandRequest, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IDataTypeRepository _dataTypeRepository;
        private readonly Mapper _mapper;
        private readonly IEmailServices _emailServices;

        public CreateLeaveRequest_CommandHandler(ILeaveRequestRepository repository, 
            IDataTypeRepository dataTypeRepository, 
            IEmailServices email, 
            Mapper mapper)
        {
            _repository = repository;
            _dataTypeRepository = dataTypeRepository;
            _mapper = mapper;
            _emailServices = email;
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

            var newEmail = new Email
            {
                From = "remcarlmerza@gmail.com",
                To = "remcarl2121@gmail.com",
                Body = $"Your leave request from {commandRequest.LeaveRequestDTO.StartDate} to {commandRequest.LeaveRequestDTO.EndDate} is been approved",
            };
            try
            {
                await _emailServices.SendEmail(newEmail);
            }
            catch(Exception ex) { 
                
            }

            return response;

        }
    }
}
