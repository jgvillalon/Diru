using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DIRU.Views.RegulacionesUrbanas.DatosEntradaDiseño;
using DropDownMenu;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Common;
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

namespace DIRU.Views.RegulacionesUrbanas.NuevoDiseño
{
    /// <summary>
    /// Interaction logic for NuevosDatosEntrada.xaml
    /// </summary>
    public partial class NuevosDatosEntrada : UserControl
    {
        private readonly IPlantaService _plantaService;
        public static DataGrid datagrid;
        public NuevosDatosEntrada()
        {
            InitializeComponent();
            _plantaService = DependencyRegister._plantaService;
            PlantaSearchOptions options = new PlantaSearchOptions { InversionLoteId = MainWindow.currentProject.InversionLotes.Id };
            dgPlanta.ItemsSource = _plantaService.FindAllPlantas(options);
            datagrid = dgPlanta;
        }

        private void GestionarPlanta_Click(object sender, RoutedEventArgs e)
        {
            var planta = (Planta)dgPlanta.SelectedItem;
            if (planta != null)
            {
                new AddNewLocalForm(planta).ShowDialog();
            }
        }
        private void dgPlanta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var planta = (Planta)dgPlanta.SelectedItem;
            if (planta != null && planta.Nuevo)
            {
                DeletePlanta.IsEnabled = true;
            }
            else
                DeletePlanta.IsEnabled = false;
        }

        private void AddPlanta_Click(object sender, RoutedEventArgs e)
        {
            int plantasCount = dgPlanta.Items.Count;
            var response = _plantaService.InsertPlanta(new Planta
            {
                InversionLote = MainWindow.currentProject.InversionLotes,
                Descripcion = "Planta No." + plantasCount,
                Nuevo = true
            });
            if (response.Status == StatusResponse.OK)
            {
                MainWindow.currentProject.InversionLotes.CantidadPlantas += 1;
                DependencyRegister._proyectoService.UpdateProyecto(MainWindow.currentProject);
                gridRefresh();
            }
            else
                new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

        }
        private void gridRefresh()
        {
            dgPlanta.SelectedItem = null;
            PlantaSearchOptions options = new PlantaSearchOptions { InversionLoteId = MainWindow.currentProject.InversionLotes.Id };
            dgPlanta.ItemsSource = _plantaService.FindAllPlantas(options);
            DeletePlanta.IsEnabled = false;
        }

        private void DeletePlanta_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la planta?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                Planta planta = dgPlanta.SelectedItem as Planta;
                if (planta != null)
                {
                    var response = _plantaService.DeletePlanta(planta.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        MainWindow.currentProject.InversionLotes.CantidadPlantas -= 1;
                        DependencyRegister._proyectoService.UpdateProyecto(MainWindow.currentProject);
                        new MessageBoxCustom("Planta eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La planta se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Planta no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
    }
}
