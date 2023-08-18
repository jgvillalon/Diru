using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Dependencies;
using DropDownMenu;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Nomencladores.Otros.Options;
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

namespace DIRU.Views.RegulacionesUrbanas.DatosEntradaDiseño
{
    /// <summary>
    /// Interaction logic for DatosEntradaDiseño.xaml
    /// </summary>
    public partial class DatosEntradaDiseño : UserControl
    {
        private readonly IPlantaService _plantaService;
        public static DataGrid datagrid;
        public DatosEntradaDiseño()
        {
            InitializeComponent();
            _plantaService = DependencyRegister._plantaService;
            PlantaSearchOptions options = new PlantaSearchOptions { InversionLoteId = MainWindow.currentProject.InversionLotes.Id, Nuevo = false };
            dgPlanta.ItemsSource = _plantaService.FindAllPlantas(options);
            datagrid = dgPlanta;
        }

        private void GestionarPlanta_Click(object sender, RoutedEventArgs e)
        {
            var planta = (Planta)dgPlanta.SelectedItem;
            if (planta != null)
            {
                new LocalesToPlantaForm(planta).ShowDialog();
            }
        }
    }
}
