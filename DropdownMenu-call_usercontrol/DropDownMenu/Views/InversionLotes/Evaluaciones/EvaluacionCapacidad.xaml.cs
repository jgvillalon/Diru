using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DropDownMenu;
using Entity.Entitys.Proyectos;
using Repository.Common;
using Repository.Proyectos.Options;
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

namespace DIRU.Views.InversionLotes.Evaluaciones
{
    /// <summary>
    /// Interaction logic for EvaluacionCapacidad.xaml
    /// </summary>
    public partial class EvaluacionCapacidad : UserControl
    {
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public static int zonaCount = 1;
        private readonly ICapacidadService _capacidadService;
        public EvaluacionCapacidad()
        {
            InitializeComponent();
           
            datagrid = dgCapacidad;
            Edit = EditCapacidad;
            Delete = DeleteCapacidad;
            _capacidadService = DependencyRegister._capacidadService;
            CapacidadSearchOptions options = new CapacidadSearchOptions { ProyectoId = MainWindow.currentProject.Id };
            var capacidades = _capacidadService.FindAllCapacidads(options);
            if (capacidades.Count > 0)
                zonaCount = capacidades.Count + 1;
            dgCapacidad.ItemsSource = capacidades;
        }
        private void AddCapacidad_Click(object sender, RoutedEventArgs e)
        {
            CapacidadForm page = new CapacidadForm(_capacidadService);
            page.ShowDialog();
        }

        private void EditCapacidad_Click(object sender, RoutedEventArgs e)
        {
            Capacidad capacidad = dgCapacidad.SelectedItem as Capacidad;
            CapacidadForm page = new CapacidadForm(_capacidadService, capacidad);
            page.ShowDialog();
        }
        private void dgCapacidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditCapacidad.IsEnabled = true;
            DeleteCapacidad.IsEnabled = true;

        }
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSearch != null)
                txtSearch.Text = string.Empty;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
    //        switch (comboFilter.Text)
    //        {
    //            case "Provincia":
    //                dgCapacidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    //((Capacidad)f).Provincia.Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
    //                dgCapacidad.Items.Refresh();
    //                break;
    //            default:
    //                dgCapacidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    //((Capacidad)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
    //                dgCapacidad.Items.Refresh();
    //                break;

    //        }
        }

        private void DeleteCapacidad_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la capacidad?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                Capacidad capacidad = dgCapacidad.SelectedItem as Capacidad;
                if (capacidad != null)
                {
                    var response = _capacidadService.DeleteCapacidad(capacidad.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Capacidad eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La zona se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Zona no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            CapacidadSearchOptions options = new CapacidadSearchOptions { ProyectoId = MainWindow.currentProject.Id };
            datagrid.ItemsSource = _capacidadService.FindAllCapacidads();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }


}

