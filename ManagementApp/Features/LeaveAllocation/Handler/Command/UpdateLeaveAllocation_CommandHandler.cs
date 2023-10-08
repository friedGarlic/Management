using AutoMapper;
using Management.Application.Contracts.Persistence;
using Management.Application.DTOs.LeaveAllocation.Validation;
using Management.Application.Exceptions;
using Management.Application.Features.LeaveAllocation.Request.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Handler.Command
{
    public class UpdateLeaveAllocation_CommandHandler : IRequestHandler<UpdateLeaveAllocation_CommandRequest, Unit>
    {
        private readonly ILeaveAllocationRepository _repository;
        private readonly IDataTypeRepository _dataTypeRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveAllocation_CommandHandler(ILeaveAllocationRepository repository, Mapper mapper, IDataTypeRepository dataTypeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _dataTypeRepository = dataTypeRepository;
        }
        public async Task<Unit> Handle (UpdateLeaveAllocation_CommandRequest request, CancellationToken token)
        {
            var updateValidator = new UpdateLeaveAllocation_ValidatorDTO(_dataTypeRepository);
            var validatorResult = await updateValidator.ValidateAsync(request.LeaveAllocationDTO);

            if (validatorResult.IsValid == false)
            {
                throw new ValidationException(validatorResult);
            }

            var leaveAlloc = await _repository.Get(request.LeaveAllocationDTO.Id);

            _mapper.Map(request.LeaveAllocationDTO, leaveAlloc);

            await _repository.Update(leaveAlloc);

            return Unit.Value;
        }
    }
}
