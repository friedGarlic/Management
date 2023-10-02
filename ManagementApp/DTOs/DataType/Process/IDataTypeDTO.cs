using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.DataType.Process
{
    public interface IDataTypeDTO
    {
        public string Name { get; set; }

        public int LeaveTypeDefaultDays { get; set; }
    }
}
