using Management.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Management.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ManagementdbContext _context;

        public LeaveRequestRepository(ManagementdbContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeLeaveRequestApproval(LeaveRequest request, bool? approval)
        {
            request.IsApproved = approval;

            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /* this method is an asynchronous function 
         * that retrieves a specific leave request based on 
         * its id from a database. It uses Entity Framework to perform this operation. 
         * The specific part here is the use of .
         * Include(q => q.Id == id) which appears to be an unusual way to filter results */
        public async Task<LeaveRequest> GetLeaveRequestDetail(int id)
        {
            var leaveRequest = await _context.DbLeaveRequest
                .Include(q => q.Id == id).FirstOrDefaultAsync();

            return leaveRequest;
        }

        /*In summary, this method is an asynchronous function that retrieves a
        list of leave requests along with their associated leave types from a database.
        It uses Entity Framework to perform this operation.
        This list is then returned as the result of the method. */
        public async Task<List<LeaveRequest>> GetLeaveRequestDetailList()
        {
            var leaveRequest = await _context.DbLeaveRequest
                .Include(q => q.LeaveType).ToListAsync();

            return leaveRequest;
        }
    }
}
