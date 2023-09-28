using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.Common;

namespace Management.Application.DTOs.DataType
{
    public class DataTypeDTO : BaseDTO, IDataTypeDTO
    {
        public string Name { get; set; }

        public int LeaveTypeDefaultDays { get; set; }
    }
}
