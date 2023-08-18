using ApplicationService.Common;
using Entity.Entitys.Proyectos;
using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Informes.IService
{
    public interface IInformeService
    {
        void GenerateInformeGeneral(Proyecto project);
    }
}
