using Management.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Contracts.Infrastructure
{
    public interface IEmailServices
    {
        Task<bool> SendEmail(Email email);

    }
}
