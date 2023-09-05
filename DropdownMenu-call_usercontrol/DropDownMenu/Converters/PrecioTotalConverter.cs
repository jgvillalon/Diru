using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DIRU.Converters
{
    public class PrecioTotalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var localPlanta = (LocalPlanta)value;

            return localPlanta.AreaOcupada* localPlanta.AccionPrecio;
           

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
