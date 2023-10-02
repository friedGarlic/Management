﻿using AutoMapper;
using Management.Application.DTOs.LeaveAllocation.Validation;
using Management.Application.Features.LeaveAllocation.Request.Command;
using Management.Application.Exceptions;
using ManagementApp.Contracts;
using MediatR;

namespace Management.Application.Features.LeaveAllocation.Handler.Command
{
    public class CreateLeaveAllocation_CommandHandler : IRequestHandler<CreateLeaveAllocation_CommandRequest, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocRepository;
        private readonly IDataTypeRepository _dataTypeRepository;
        private readonly Mapper _mapper;
        

        public CreateLeaveAllocation_CommandHandler(ILeaveAllocationRepository leaveAllocRepository, 
            IDataTypeRepository dataTypeRepository, Mapper mapper)
        {
            _leaveAllocRepository = leaveAllocRepository;
            _dataTypeRepository = dataTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocation_CommandRequest request, CancellationToken cancellationToken)
        {
            //TODO REMINDER THIS IS NOT CreateLeaveAllocation_ValidatorDTO
            var validator = new ILeaveAllocation_ValidatorDTO(_dataTypeRepository);

            var validatorResult = await validator.ValidateAsync(request.LeaveAllocationDTO);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);

            var leaveAlloc = _mapper.Map<Management.LeaveAllocation>(request.LeaveAllocationDTO);

            leaveAlloc = await _leaveAllocRepository.Add(leaveAlloc);

            return leaveAlloc.Id;
        }
    }
}
