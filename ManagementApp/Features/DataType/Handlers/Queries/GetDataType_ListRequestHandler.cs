using AutoMapper;
using Management.Application.DTOs.DataType;
using Management.Application.Features.DataType.Requests.Queries;
using ManagementApp.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.DataType.Handlers.Queries
{
    internal class GetDataType_ListRequestHandler : IRequestHandler<GetDataType_ListRequest, List<DataTypeDTO>>
    {
        public readonly IDataTypeRepository _dataTypeRepository;
        private readonly IMapper _mapper;


        public GetDataType_ListRequestHandler(IDataTypeRepository dataTypeRepository, IMapper mapper)
        {
            _dataTypeRepository = dataTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<DataTypeDTO>> Handle(GetDataType_ListRequest request, CancellationToken cancellationToken)
        {
            var dataType = await _dataTypeRepository.GetAll();
            return _mapper.Map<List<DataTypeDTO>>(dataType);
        }
    }
}
