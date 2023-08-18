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
    public interface IOrganismoService
    {
        Response InsertOrganismo(Organismo organismo);
        Response UpdateOrganismo(Organismo organismo);
        Response DeleteOrganismo(int organismoId);
        Organismo GetOrganismobyId(int organismoId);
        List<Organismo> FindAllOrganismos(OrganismoSearchOptions options = null);
    }
}
