using Repository.Seguridad.IRepository;
using Entity.Entitys.Seguridad;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seguridad.Repository
{
    public class LicenseRepository : TRepository, ILicenseRepository
    {
        private readonly ISession _session;
        public LicenseRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public License GetLicense(string encryptCode)
        {
            return _session.Query<License>().FirstOrDefault(l => l.Codigo.Equals(encryptCode));
        }
    }
}
