using AutoMapper;
using Management.Application.Contracts.Persistence;
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
    public class DeleteLeaveAllocation_CommandHandler : IRequestHandler<DeleteLeaveAllocation_CommandRequest, int>
    {
        private readonly ILeaveAllocationRepository _repository;
        private readonly Mapper _mapper;

        public DeleteLeaveAllocation_CommandHandler(ILeaveAllocationRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteLeaveAllocation_CommandRequest request, CancellationToken cancellationToken)
        {
            var idRequest = await _repository.Get(request.Id);

            if (idRequest == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation),request.Id);
            }

            await _repository.Delete(idRequest);

            return idRequest.Id;
        }
    }
}
