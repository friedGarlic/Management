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
    internal class GetDataTypeDetailRequestHandler : IRequestHandler<GetDataTypeDetailRequest, DataTypeDTO>
    {
        public readonly IDataTypeRepository _dataTypeRepository;
        private readonly IMapper _mapper;


        public GetDataTypeDetailRequestHandler(IDataTypeRepository dataTypeRepository, IMapper mapper)
        {
            _dataTypeRepository = dataTypeRepository;
            _mapper = mapper;
        }
        public async Task<DataTypeDTO> Handle(GetDataTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var dataType = await _dataTypeRepository.GetAll();
            return _mapper.Map<DataTypeDTO>(dataType);
        }
    }
}
