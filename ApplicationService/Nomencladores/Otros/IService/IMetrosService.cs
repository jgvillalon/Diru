using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Otros;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Otros.IService
{
    public interface IMetrosService
    {
        Response InsertMetros(Metros metros);
        Response UpdateMetros(Metros metros);
        Response DeleteMetros(int metrosId);
        Metros GetMetrosbyId(int metrosId);
        List<Metros> FindAllMetros(MetrosSearchOptions options = null);
    }
}
