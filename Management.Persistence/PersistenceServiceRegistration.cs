using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Persistence
{
    public class PersistenceServiceRegistration
    {
        public PersistenceServiceRegistration()
        {
            
        }

        public static IServiceCollection ConfigurePersistenceServices(IServiceCollection services, 
            IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
