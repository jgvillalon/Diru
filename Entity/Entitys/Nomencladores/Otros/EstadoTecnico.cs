using Entity.Entitys.Nomencladores.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Otros
{
    public class EstadoTecnico
    {
        public virtual int Id { get; set; }
        public virtual string Elementos { get; set; }
        public virtual int MinBueno { get; set; }
        public virtual int MaxBueno { get; set; }
        public virtual int MinRegular { get; set; }
        public virtual int MaxRegular { get; set; }
        public virtual int MinMalo { get; set; }
        public virtual int MaxMalo { get; set; }
        
        public virtual bool Active { get; set; }

        public virtual string RangoBueno => $"{MinBueno} - {MaxBueno}";
        public virtual string RangoMalo => $"{MinMalo} - {MaxMalo}";
        public virtual string RangoRegular => $"{MinRegular} - {MaxRegular}";

        public virtual ElementoEstado Rango(int valor) {

            var rangoB1 = MinBueno;
            var rangoB2 = MaxBueno;
            if(valor <= rangoB2 && valor <= rangoB1)
                return ElementoEstado.Bueno;
            var rangoM1 = MinMalo;
            var rangoM2 = MaxMalo;
            if (valor <= rangoM2 && valor <= rangoM1)
                return ElementoEstado.Malo;
            var rangoR1 = MinRegular;
            var rangoR2 = MaxRegular;
             if (valor <= rangoR2 && valor <= rangoR1)
                return ElementoEstado.Regular;

            return ElementoEstado.None;

        }
    }
}
