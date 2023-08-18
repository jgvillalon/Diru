using Entity.Entitys.Nomencladores.Generales;
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

namespace DIRU.Views.RegulacionesUrbanas.Indicadores
{
    /// <summary>
    /// Interaction logic for IndicadoresProyecto.xaml
    /// </summary>
    public partial class IndicadoresProyecto : UserControl
    {
        public IndicadoresProyecto()
        {
            InitializeComponent();
        }

        private void AddIndicaador_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditIndicaador_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteIndicaador_Click(object sender, RoutedEventArgs e)
        {

        }
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSearch != null)
                txtSearch.Text = string.Empty;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
        

            
        }

        private void dgIndicaador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
