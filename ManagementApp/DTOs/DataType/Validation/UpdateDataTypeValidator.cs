using FluentValidation;
using Management.Application.DTOs.DataType.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.DataType.Validation
{
    internal class UpdateDataTypeValidator : AbstractValidator<DataTypeDTO>
    {
        public UpdateDataTypeValidator()
        {
            IDataTypeValidator iValidator = new IDataTypeValidator();

            Include(iValidator);

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is null");
        }
    }
}
