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
    public interface IOrganismoRepository
    {
        List<Organismo> FindAllOrganismos(OrganismoSearchOptions options);
        StatusResponse InsertOrganismo(Organismo organismo);
        StatusResponse UpdateOrganismo(Organismo organismo);
        StatusResponse DeleteOrganismo(Organismo organismo);
        Organismo GetOrganismobyId(int organismoId);
    }
}
