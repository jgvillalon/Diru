using Entity.Entitys.Nomencladores.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.InversionesLotes
{
    public class InversionLote
    {
        public InversionLote() {
           
            Plantas = new List<Planta>();
            Redes = new List<Red>();
        
        }
        public virtual int Id { get; set; }
        public virtual int NoTerreno { get; set; }
        public virtual int CantidadPlantas { get; set; }
        public virtual decimal AreaLotes { get; set; }
        public virtual decimal SuperficieVerde { get; set; }
        public virtual decimal SuperficieHidrica { get; set; }
        public virtual decimal ProfundidadManto { get; set; }
        public virtual decimal TopografiaPendiente { get; set; }
        public virtual string ValoresPaisajisticos { get; set; }
        public virtual int CantidadHabitantes { get; set; }
        public virtual string ViasTransportePublico { get; set; }
        public virtual string UrlEvaluaciones { get; set; }
        public virtual IList<Planta> Plantas { get; set; }
        public virtual IList<Red> Redes { get; set; }
        //public virtual Red Red { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        #region Plantas
        public virtual void AddPlanta(Planta planta)
        {
            planta.InversionLote = this;
            Plantas.Add(planta);
        }
        public virtual void AddPlantas(IEnumerable<Planta> plantas)
        {
            foreach (var planta in plantas)
            {
                AddPlanta(planta);
            }
        }
        public virtual void RemovePlanta(Planta planta)
        {
            Plantas.Remove(planta);

        }
        public virtual void RemovePlantas(IEnumerable<Planta> plantaes)
        {
            foreach (var planta in plantaes)
            {
                RemovePlanta(planta);

            }

        }
        public virtual void RemoveAllPlantas()
        {
            Plantas.Clear();
        }
        #endregion

        #region Red
        public virtual void AddRed(Red red)
        {
            //red.InversionLote = this;
            Redes.Add(red);
        }
        public virtual void AddRedes(IEnumerable<Red> redes)
        {
            foreach (var red in redes)
            {
                AddRed(red);
            }
        }
        public virtual void RemoveRed(Red red)
        {
            Redes.Remove(red);

        }
        public virtual void RemoveRedes(IEnumerable<Red> redes)
        {
            foreach (var red in redes)
            {
                RemoveRed(red);

            }

        }
        public virtual void RemoveAllRedes()
        {
            Redes.Clear();
        }
        #endregion
    }
}
