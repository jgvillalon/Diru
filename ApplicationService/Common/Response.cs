using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Common
{
   public class Response
    {
        public StatusResponse Status { get; set; }
        public string Message { get; set; }
    }
}
