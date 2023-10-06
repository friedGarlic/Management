using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime LastModifiedDate { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
