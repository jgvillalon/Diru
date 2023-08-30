using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Common;
using Repository.Nomencladores.Generales.Options;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.IRepository
{
    public interface IRedRepository
    {
        List<Red> FindAllReds(RedSearchOptions options);
        StatusResponse InsertRed(Red Red);
        StatusResponse UpdateRed(Red Red);
        StatusResponse DeleteRed(Red Red);
        Red GetRedbyId(int RedId);
    }
}
