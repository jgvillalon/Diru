using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public class DateFilter
    {
        public virtual DateTime Fecha { get; set; }
        public virtual DateOperator Operator { get; set; }
    }
}
