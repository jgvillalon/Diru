using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Generales.IService
{
    public interface ILocalService
    {
        Response InsertLocal(Local local);
        Response UpdateLocal(Local local);
        Response DeleteLocal(int localId);
        Local GetLocalbyId(int localId);
        List<Local> FindAllLocals(LocalSearchOptions options = null);
    }
}
