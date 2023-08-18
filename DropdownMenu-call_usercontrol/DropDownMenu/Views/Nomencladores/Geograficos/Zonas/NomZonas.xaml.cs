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

namespace DIRU.Views.Nomencladores.Geograficos.Zonas
{
    /// <summary>
    /// Interaction logic for NomZonas.xaml
    /// </summary>
    public partial class NomZonas : UserControl
    {
        private readonly IZonaUbicacionService _zonaUbicacionService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomZonas()
        {
            InitializeComponent();
  _zonaUbicacionService = DependencyRegister._zonaUbicacionService;

            dgZona.ItemsSource = _zonaUbicacionService.FindAllZonaUbicacions();
            datagrid = dgZona;
            Edit = EditZona;
            Delete = DeleteZona;
        }
        private void AddZona_Click(object sender, RoutedEventArgs e)
        {
            ZonasForm page = new ZonasForm(_zonaUbicacionService);
            page.ShowDialog();
        }

        private void EditZona_Click(object sender, RoutedEventArgs e)
        {
            ZonaUbicacion zonaUbicacion = dgZona.SelectedItem as ZonaUbicacion;
            ZonasForm page = new ZonasForm(_zonaUbicacionService, zonaUbicacion);
            page.ShowDialog();
        }
        private void dgZona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditZona.IsEnabled = true;
            DeleteZona.IsEnabled = true;

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
                    dgZona.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((ZonaUbicacion)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgZona.Items.Refresh();
                    break;

            }
        }

        private void DeleteZona_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la zona?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                ZonaUbicacion zonaUbicacion = dgZona.SelectedItem as ZonaUbicacion;
                if (zonaUbicacion != null)
                {
                    var response = _zonaUbicacionService.DeleteZonaUbicacion(zonaUbicacion.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Ubicacion eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La zona se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
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
            datagrid.ItemsSource = _zonaUbicacionService.FindAllZonaUbicacions();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }


}

