using Entity.Entitys.Nomencladores.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.InversionesLotes
{
    public class Planta
    {
        public Planta() {

            Locales = new List<LocalPlanta>();
        }
        public virtual int Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual decimal Area { get; set; }
        public virtual IList<LocalPlanta> Locales { get; set; }
     
        public virtual InversionLote InversionLote { get; set; }
        public virtual bool Nuevo { get; set; }

        #region Locales
        public virtual void AddLocalPlanta(LocalPlanta local)
        {
            local.Planta = this;
           Locales.Add(local);
        }
        public virtual void AddLocales(IEnumerable<LocalPlanta> locals)
        {
            foreach (var local in locals)
            {
                AddLocalPlanta(local);
            }
        }
        public virtual void RemoveLocalPlanta(LocalPlanta local)
        {
            Locales.Remove(local);

        }
        public virtual void RemoveLocales(IEnumerable<LocalPlanta> locales)
        {
           foreach (var local in locales)
            {
                RemoveLocalPlanta(local);

            }

        }
        public virtual void RemoveAllLocales()
        {
            Locales.Clear();
        }
        #endregion
    }
}
