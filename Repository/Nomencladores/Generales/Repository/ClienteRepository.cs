using Entity.Entitys.Nomencladores.Generales;
using NHibernate;
using Repository.Common;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Generales.Repository
{
   public class ClienteRepository : TRepository, IClienteRepository
    {
        private readonly ISession _session;
        public ClienteRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteCliente(Cliente cliente)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(cliente);
                    transaction.Commit();

                }
                return StatusResponse.OK;
            }
            catch (Exception e)
            {
                _session.Clear();
                var msg = e.InnerException.Message;
                if (msg.Contains("23503:"))
                    return StatusResponse.InUse;
                return StatusResponse.Error;
            }
        }

        public List<Cliente> FindAllClientes(ClienteSearchOptions options = null)
        {
            var query = _session.Query<Cliente>();
            if (options != null)
            {

                //if (options.Active.HasValue)
                //    query = query.Where(o => o.Active == options.Active.Value);

            }
            query = query.OrderByDescending(l => l.Id);
            return query.ToList();
        }

        public Cliente GetClientebyId(int clienteId)
        {
            return _session.Query<Cliente>().FirstOrDefault(u => u.Id.Equals(clienteId));
        }



        public StatusResponse InsertCliente(Cliente cliente)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(cliente);
                    transaction.Commit();

                }
                return StatusResponse.OK;
            }
            catch (Exception e)
            {
                _session.Clear();
                var msg = e.InnerException.Message;
                if (msg.Contains("23505:"))
                    return StatusResponse.Exist;

                return StatusResponse.Error;

            }
        }

        public StatusResponse UpdateCliente(Cliente cliente)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(cliente);
                    transaction.Commit();

                }
                return StatusResponse.OK;
            }
            catch (Exception)
            {
                _session.Clear();
                return StatusResponse.Error;
            }
        }



    }
}
