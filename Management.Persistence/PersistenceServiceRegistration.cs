using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Management.Persistence.Repositories;
using Management.Application.Contracts.Persistence;

namespace Management.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ManagementdbContext>(option => option.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
                ));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IDataTypeRepository,DataTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}
