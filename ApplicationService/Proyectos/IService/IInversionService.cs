using ApplicationService.Common;
using Entity.Entitys.Proyectos;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Inversions.IService
{
   public interface IInversionService
    {
        Response InsertInversion(Inversion inversion);
        Response UpdateInversion(Inversion inversion);
        Response DeleteInversion(int inversionId);
        Inversion GetInversionbyId(int inversionId);
        List<Inversion> FindAllInversions(InversionSearchOptions options = null);
    }
}
