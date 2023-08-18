using ApplicationService.Nomencladores.Geograficos.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using Entity.Entitys.Nomencladores.Geograficos;
using Repository.Common;
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

namespace DIRU.Views.Nomencladores.Geograficos.Ubicaciones
{
    /// <summary>
    /// Interaction logic for NomUbicaciones.xaml
    /// </summary>
    public partial class NomUbicaciones : UserControl
    {
        private readonly IUbicacionGeograficaService _ubicacionGeograficaService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomUbicaciones()
        {
            InitializeComponent();
            _ubicacionGeograficaService = DependencyRegister._ubicacionGeograficaService;

            dgUbicacion.ItemsSource = _ubicacionGeograficaService.FindAllUbicacionGeograficas();
            datagrid = dgUbicacion;
            Edit = EditUbicacion;
            Delete = DeleteUbicacion;
        }
        private void AddUbicacion_Click(object sender, RoutedEventArgs e)
        {
            UbicacionesForm page = new UbicacionesForm(_ubicacionGeograficaService);
            page.ShowDialog();
        }

        private void EditUbicacion_Click(object sender, RoutedEventArgs e)
        {
            UbicacionGeografica ubicacionGeografica = dgUbicacion.SelectedItem as UbicacionGeografica;
            UbicacionesForm page = new UbicacionesForm(_ubicacionGeograficaService, ubicacionGeografica);
            page.ShowDialog();
        }
        private void dgUbicacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditUbicacion.IsEnabled = true;
            DeleteUbicacion.IsEnabled = true;

        }
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSearch != null)
                txtSearch.Text = string.Empty;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            switch (comboFilter.Text)
            {
                
                default:
                    dgUbicacion.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((UbicacionGeografica)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgUbicacion.Items.Refresh();
                    break;

            }
        }

        private void DeleteUbicacion_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la ubicacion?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                UbicacionGeografica ubicacionGeografica = dgUbicacion.SelectedItem as UbicacionGeografica;
                if (ubicacionGeografica != null)
                {
                    var response = _ubicacionGeograficaService.DeleteUbicacionGeografica(ubicacionGeografica.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Ubicacion eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La ubicacion se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Ubicacion no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            datagrid.ItemsSource = _ubicacionGeograficaService.FindAllUbicacionGeograficas();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }


}

