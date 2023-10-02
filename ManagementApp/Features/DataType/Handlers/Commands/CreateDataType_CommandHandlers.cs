using AutoMapper;
using Management.Application.Features.DataType.Requests.Commands;
using ManagementApp.Contracts;
using MediatR;
using Management.Application.DTOs.DataType.Validation;
using Management.Application.Exceptions;

namespace Management.Application.Features.DataType.Handlers.Commands
{
    public class CreateDataType_CommandHandlers : IRequestHandler<CreateDataType_CommandRequest, int>
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
            var validatorResult = await validator.ValidateAsync(request.DataTypeDTO);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);
            
            var dataType = _mapper.Map<Management.DataType>(request.DataTypeDTO);

            dataType = await _repository.Add(dataType);

            return dataType.Id;
        }
    }
}
