using AutoMapper;
using FluentValidation;
using Management.Application.DTOs.DataType.Validation;
using Management.Application.DTOs.LeaveAllocation.Validation;
using Management.Application.DTOs.LeaveRequest.Validator;
using Management.Application.Features.LeaveRequest.Request.Command;
using ManagementApp.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Handler.Command
{
    internal class CreateLeaveRequest_CommandHandler : IRequestHandler<CreateLeaveRequest_CommandRequest, int>
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
            var validator = new ILeaveRequest_ValidatorDTO(_dataTypeRepository);

            //TODO REMINDER THIS IS NOT CreateLeaveRequest_ValidatorDTO
            var validatorResult = await validator.ValidateAsync(commandRequest.LeaveRequestDTO);

            if (validatorResult != null)
            {
                throw new Exception();
            }

            var leaveRequest = _mapper.Map<Management.LeaveRequest>(commandRequest);

            leaveRequest = await _repository.Add(leaveRequest);
            
            return leaveRequest.Id;
        }
    }
}
