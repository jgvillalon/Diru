using Entity.Entitys.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Seguridad.IServices
{
    public interface ILicenseService
    {
        License GetLicense();
    }
}
