using Entity.Entitys.Proyectos;
using Repository.Common;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Inversions.IRepository
{
   public interface IInversionRepository
    {
        List<Inversion> FindAllInversions(InversionSearchOptions options);
        StatusResponse InsertInversion(Inversion inversion);
        StatusResponse UpdateInversion(Inversion inversion);
        StatusResponse DeleteInversion(Inversion inversion);
        Inversion GetInversionbyId(int inversionId);
    }
}
