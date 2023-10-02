using AutoMapper;
using Management.Application.Features.DataType.Requests.Commands;
using ManagementApp.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.DataType.Handlers.Commands
{
    public class UpdateDataType_CommandHandlers : IRequestHandler<UpdateDataType_CommandRequest, Unit>
    {

        private readonly IDataTypeRepository _repository;
        private readonly Mapper _mapper;

        public UpdateDataType_CommandHandlers(IDataTypeRepository repository, Mapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDataType_CommandRequest request, CancellationToken cancellationToken)
        {
            var dataType = await _repository.Get(request.DataTypeDTO.Id);

            _mapper.Map(request.DataTypeDTO, dataType);

            await _repository.Update(dataType);

            return Unit.Value;
        }
    }
}
