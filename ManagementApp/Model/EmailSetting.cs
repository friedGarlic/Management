using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Model
{
    public class EmailSetting
    {
        public string APIkey { get; set; }

        public string FromAddress { get; set; }

        public string FromName { get; set; }
    }
}
