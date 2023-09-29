using AutoMapper.Configuration;
using FluentValidation;
using Management.Application.DTOs.DataType.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.DataType.Validation
{
    internal class IDataTypeValidator : AbstractValidator<IDataTypeDTO>
    {
        public IDataTypeValidator()
        {
            RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} needs to be less than 50 characters")
                    .MinimumLength(1).WithMessage("{PropertyName} needs to be more that 1 character");

            RuleFor(p => p.LeaveTypeDefaultDays)
                    .NotEmpty().WithMessage("{PropertyName} is required")
                    .NotNull()
                    .LessThan(6).WithMessage("{PropertyName} can only be less than 6");
        }
    }
}
