using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIRU.Views.RegulacionesUrbanas.Edificacion
{
    /// <summary>
    /// Interaction logic for Alineacion.xaml
    /// </summary>
    public partial class Alineacion : UserControl
    {
        public Alineacion()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionPatio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionFranjaJardin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionAcera_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionCercado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionPatioInterior_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionPasilloFondo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionPasilloLateral_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionPortalCorrido_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionPortal_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }


        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        private void ObservacionRectangulo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
