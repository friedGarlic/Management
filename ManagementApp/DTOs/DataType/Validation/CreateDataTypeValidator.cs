using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Management.Application.DTOs.DataType.Process;

namespace Management.Application.DTOs.DataType.Validation
{

    //TODO REMINDER this is a DATATYPEDTO as field parameter not CreateDataTypeDTO
    public class CreateDataTypeValidator : AbstractValidator<DataTypeDTO>
    {
        public CreateDataTypeValidator()
        {
            IDataTypeValidator iValidator = new IDataTypeValidator();

            Include(iValidator);
        }
    }
}
