
using Management.Application.Contracts.Infrastructure;
using Management.Application.Model;
using Management.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection service, IConfiguration configure)
        {
            service.Configure<EmailSetting>(configure.GetSection("EmailSetting"));
            service.AddTransient<IEmailServices, EmailServices>();

            return service;
        }
    }
}
