using AutoMapper;
using Management.Application.Exceptions;
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
    public class DeleteLeaveRequest_CommandHandler : IRequestHandler<DeleteLeaveRequest_CommandRequest, Unit>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly Mapper _mapper;

        public DeleteLeaveRequest_CommandHandler(ILeaveRequestRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequest_CommandRequest commandRequest, CancellationToken token)
        {
            var request = await _repository.Get(commandRequest.ID);

            if (request == null)
            {
                throw new NotFoundException(nameof(commandRequest), commandRequest.ID);
            }

            await _repository.Delete(request);

            return Unit.Value;
        }
    }
}
