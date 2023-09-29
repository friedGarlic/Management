using AutoMapper;
using Management.Application.Features.DataType.Requests.Commands;
using ManagementApp.Contracts;
using MediatR;
using Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.DataType.Validation;
using FluentValidation;
using Management.Application.DTOs.DataType.Process;

namespace Management.Application.Features.DataType.Handlers.Commands
{
    internal class CreateDataType_CommandHandlers : IRequestHandler<CreateDataType_CommandRequest, int>
    {
        private readonly IDataTypeRepository _repository;
        private readonly IMapper _mapper;

        public CreateDataType_CommandHandlers(IDataTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDataType_CommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateDataTypeValidator();
            var validatorResult = await validator.ValidateAsync((CreateDataTypeDTO)request.DataTypeDTO);

            if (validatorResult.IsValid == false)
                throw new NotImplementedException();
            
            var dataType = _mapper.Map<Management.DataType>(request.DataTypeDTO);

            dataType = await _repository.Add(dataType);

            return dataType.Id;
        }
    }
}
