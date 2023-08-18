using Entity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TRepository
    {
        protected readonly ISession _session;

        public TRepository()
        {
            Connection conexion = new Connection();
            _session = conexion.Open();
        }

        public TRepository(ISession session)
        {
           _session = session;  
        }
    }
}
