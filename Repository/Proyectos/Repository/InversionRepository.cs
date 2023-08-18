using Entity.Entitys.Proyectos;
using NHibernate;
using Repository.Common;
using Repository.Inversions.IRepository;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Inversions.Repository
{
    public class InversionRepository : TRepository, IInversionRepository
    {
        private readonly ISession _session;
        public InversionRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteInversion(Inversion inversion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(inversion);
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

        public List<Inversion> FindAllInversions(InversionSearchOptions options = null)
        {
            var query = _session.Query<Inversion>();
            if (options != null)
            {

               

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public Inversion GetInversionbyId(int inversionId)
        {
            return _session.Query<Inversion>().FirstOrDefault(u => u.Id.Equals(inversionId));
        }



        public StatusResponse InsertInversion(Inversion inversion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(inversion);
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

        public StatusResponse UpdateInversion(Inversion inversion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(inversion);
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
