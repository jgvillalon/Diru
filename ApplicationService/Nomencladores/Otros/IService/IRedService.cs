using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Nomencladores.Generales.Options;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Otros.IService
{
    public interface IRedService
    {
        Response InsertRed(Red Red);
        Response UpdateRed(Red Red);
        Response DeleteRed(int RedId);
        Red GetRedbyId(int RedId);
        List<Red> FindAllReds(RedSearchOptions options = null);
    }
}
