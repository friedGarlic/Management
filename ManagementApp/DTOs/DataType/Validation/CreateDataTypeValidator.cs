using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Management.Application.DTOs.DataType.Process;

namespace Management.Application.DTOs.DataType.Validation
{
    internal class CreateDataTypeValidator : AbstractValidator<CreateDataTypeDTO>
    {
        public CreateDataTypeValidator()
        {
            IDataTypeValidator iValidator = new IDataTypeValidator();

            Include(iValidator);
        }
    }
}
