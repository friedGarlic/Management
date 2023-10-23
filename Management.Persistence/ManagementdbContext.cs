using Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace Management.Persistence
{
    public class ManagementdbContext : DbContext
    {
        public ManagementdbContext(DbContextOptions<ManagementdbContext> options) : base(options)
        {}

        public DbSet<DataType> DbDataType { get; set; }
        public DbSet<LeaveAllocation> DbLeaveAllocation { get; set; }
        public DbSet<LeaveRequest> DbLeaveRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //to see the data base table
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagementdbContext).Assembly);
        }

        public override Task<int>SaveChangesAsync(CancellationToken token = default)
        {
            foreach(var entries in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entries.Entity.LastModifiedDate = DateTime.Now;

                if(entries.State == EntityState.Added)
                {
                    entries.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(token);
        }

    }
}