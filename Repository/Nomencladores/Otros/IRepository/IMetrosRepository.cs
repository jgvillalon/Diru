using Entity.Entitys.Nomencladores.Otros;
using Repository.Common;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.IRepository
{
    public interface IMetrosRepository
    {
        List<Metros> FindAllMetros(MetrosSearchOptions options);
        StatusResponse InsertMetros(Metros metros);
        StatusResponse UpdateMetros(Metros metros);
        StatusResponse DeleteMetros(Metros metros);
        Metros GetMetrosbyId(int metrosId);
    }
}
