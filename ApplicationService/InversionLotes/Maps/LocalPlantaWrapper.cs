using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.InversionLotes.Maps
{
    public class LocalPlantaWrapper : INotifyPropertyChanged
    {
        private LocalPlanta _model;

        public LocalPlantaWrapper(LocalPlanta model)
        {
            _model = model;
        }

        public LocalPlanta intance
        {
            get { return _model; }
            set
            {
                if (_model!= value)
                {
                    _model = value;
                }
            }
        }
        public decimal AccionPrecio
        {
            get { return _model.AccionPrecio; }
            set
            {
                if (_model.AccionPrecio != value)
                {
                    _model.AccionPrecio = value;
                    OnPropertyChanged(nameof(AccionPrecio));
                }
            }
        }

        // Implementar INotifyPropertyChanged (omitiendo otros miembros)

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
