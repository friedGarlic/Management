using Management.Application.Contracts.Persistence;
using Management.Application.Exceptions;
using Management.Application.Features.DataType.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.DataType.Handlers.Commands
{
    public class DeleteDataType_CommandHandlers : IRequestHandler<DeleteDataType_CommandRequest, int>
    {
        private readonly IDataTypeRepository _repository;

        public DeleteDataType_CommandHandlers(IDataTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteDataType_CommandRequest request, CancellationToken)
        {
            var getID = await _repository.Get(request.Id);

            if(request == null)
            {
                throw new NotFoundException(nameof(DataType), request.Id);
            }

            _repository.Delete(getID);

            return getID.Id;
        }
    }
}
