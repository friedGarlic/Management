using AutoMapper;
using FluentValidation;
using Management.Application.DTOs.LeaveAllocation;
using Management.Application.DTOs.LeaveAllocation.Validation;
using Management.Application.DTOs.LeaveRequest.Validator;
using Management.Application.Features.LeaveAllocation.Request.Command;
using ManagementApp.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Handler.Command
{
    internal class CreateLeaveAllocation_CommandHandler : IRequestHandler<CreateLeaveAllocation_CommandRequest, int>
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
            {
                throw new Exception();
            }

            var leaveAlloc = _mapper.Map<Management.LeaveAllocation>(request.LeaveAllocationDTO);

            leaveAlloc = await _leaveAllocRepository.Add(leaveAlloc);

            return leaveAlloc.Id;
        }
    }
}
