using ManagementApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ManagementdbContext _context;

        public LeaveAllocationRepository(ManagementdbContext context) : base(context)
        {
            _context = context;
        }

        public Task<LeaveAllocation> GetLeaveAllocationDetail(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationDetailList()
        {
            throw new NotImplementedException();
        }
    }
}
