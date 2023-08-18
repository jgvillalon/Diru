using Entity.Entitys.Nomencladores.Generales;
using Repository.Common;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Generales.IRepository
{
    public interface ILocalRepository
    {
        List<Local> FindAllLocals(LocalSearchOptions options);
        StatusResponse InsertLocal(Local local);
        StatusResponse UpdateLocal(Local local);
        StatusResponse DeleteLocal(Local local);
        Local GetLocalbyId(int localId);
    }
}
