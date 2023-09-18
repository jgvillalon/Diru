using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using Repository.Common;
using Repository.RegulacionesUrbanas.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RegulacionesUrbanas.IRepository
{
   public interface IUsosFuncionesRepository
    {
        List<UsosFuncionesRU> FindAllUsosFuncioness(UsosFuncionesSearchOptions options);
        StatusResponse InsertUsosFunciones(UsosFuncionesRU UsosFunciones);
        StatusResponse UpdateUsosFunciones(UsosFuncionesRU UsosFunciones);
        StatusResponse DeleteUsosFunciones(UsosFuncionesRU UsosFunciones);
        UsosFuncionesRU GetUsosFuncionesbyId(int UsosFuncionesId);
    }
}
