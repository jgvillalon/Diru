using Entity.Entitys.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seguridad.IRepository
{
    public interface ILicenseRepository
    {
        License GetLicense(string encryptCode);
    }
}
