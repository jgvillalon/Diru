using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Connection
    {
        private ISession _session;
        public ISession Open()
        {

            var configuration = new Configuration().Configure(@"hibernate.cfg.xml");
            var _sessionFactory = Fluently.Configure(configuration)
                 .Mappings(x => x.FluentMappings.AddFromAssembly(GetType().Assembly))
                  .ExposeConfiguration(cfg => {
                      new SchemaUpdate(cfg).Execute(true, true);
                      cfg.SetProperty(NHibernate.Cfg.Environment.DefaultBatchFetchSize, "100");
                  })
                 .BuildSessionFactory();

            _session = _sessionFactory.OpenSession();

            return _session;

        }

        public void Close()
        {
            _session.Close();
        }
    }




}
