﻿using AutoMapper;
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
    internal class DeleteLeaveAllocation_CommandHandler : IRequestHandler<DeleteLeaveAllocation_CommandRequest, int>
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
            //get id of request
            var leaveAlloc = await _repository.Get(request.LeaveAllocationDTO.Id);
            //delete
            await _repository.Delete(leaveAlloc);

            return leaveAlloc.Id;
        }
    }
}