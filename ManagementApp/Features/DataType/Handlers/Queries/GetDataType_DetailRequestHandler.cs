using AutoMapper;
using Management.Application.Contracts.Persistence;
using Management.Application.DTOs.DataType.Process;
using Management.Application.Features.DataType.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.DataType.Handlers.Queries
{
    public class GetDataType_DetailRequestHandler : IRequestHandler<GetDataType_DetailRequest, DataTypeDTO>
    {
        public readonly IDataTypeRepository _dataTypeRepository;
        private readonly IMapper _mapper;


        public GetDataType_DetailRequestHandler(IDataTypeRepository dataTypeRepository, IMapper mapper)
        {
            _dataTypeRepository = dataTypeRepository;
            _mapper = mapper;
        }
        public async Task<DataTypeDTO> Handle(GetDataType_DetailRequest request, CancellationToken cancellationToken)
        {
            var dataType = await _dataTypeRepository.Get(request.Id); //id object
            return _mapper.Map<DataTypeDTO>(dataType);
        }
    }
}
