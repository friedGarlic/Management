using AutoMapper;
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
    internal class UpdateLeaveRequest_CommandHandler : IRequestHandler<UpdateLeaveRequest_CommandRequest, Unit>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly Mapper _mapper;

        public UpdateLeaveRequest_CommandHandler(ILeaveRequestRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequest_CommandRequest commandRequest, CancellationToken token)
        {
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
