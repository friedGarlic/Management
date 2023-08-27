using AutoMapper;
using Management.Application.DTOs.Common;
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
    internal class GetDataTypeListRequestHandler : IRequestHandler<GetDataTypeListRequest, List<DataTypeDTO>>
    {
        public readonly IDataTypeRepository _dataTypeRepository;
        private readonly IMapper _mapper;


        public GetDataTypeListRequestHandler(IDataTypeRepository dataTypeRepository, IMapper mapper)
        {
            _dataTypeRepository = dataTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<DataTypeDTO>> Handle(GetDataTypeListRequest request, CancellationToken cancellationToken)
        {
            var dataType = await _dataTypeRepository.GetAll();
            return _mapper.Map<List<DataTypeDTO>>(dataType);
        }
    }
}
