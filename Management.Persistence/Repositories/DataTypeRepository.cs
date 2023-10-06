using ManagementApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Persistence.Repositories
{
    public class DataTypeRepository : GenericRepository<DataType>, IDataTypeRepository
    {
        private readonly ManagementdbContext _context;

        public DataTypeRepository(ManagementdbContext context) : base(context)
        {
            _context = context;
        }
    }
}
