﻿using AutoMapper;
using Management.Application.Contracts.Persistence;
using Management.Application.DTOs.DataType.Process;
using Management.Application.Features.DataType.Requests.Queries;
using MediatR;

namespace Management.Application.Features.DataType.Handlers.Queries
{
    public class GetDataType_ListRequestHandler : IRequestHandler<GetDataType_ListRequest, List<DataTypeDTO>>
    {
        private readonly IDataTypeRepository _dataTypeRepository;
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
