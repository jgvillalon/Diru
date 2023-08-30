using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DIRU.Views.Nomencladores.Otros.EstadosTecnico;
using Entity.Entitys.Nomencladores.Otros;
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

namespace DIRU.Views.Nomencladores.Otros.AccionPrecioEstandar
{
    /// <summary>
    /// Interaction logic for NomAccionPrecio.xaml
    /// </summary>  
   
    public partial class NomAccionPrecio : UserControl
    {
        private readonly IAccionPrecioService _accionPrecioService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomAccionPrecio()
        {
            InitializeComponent();
            _accionPrecioService = DependencyRegister._accionPrecioService;

            dgAccionPrecio.ItemsSource = _accionPrecioService.FindAllAccionPrecios();
            datagrid = dgAccionPrecio;
            Edit = EditAccionPrecio;
            Delete = DeleteAccionPrecio;
        }
        private void AddAccionPrecio_Click(object sender, RoutedEventArgs e)
        {
            AccionPrecioForm page = new AccionPrecioForm(_accionPrecioService);
            page.ShowDialog();
        }

        private void EditAccionPrecio_Click(object sender, RoutedEventArgs e)
        {
            AccionPrecio accionPrecio = dgAccionPrecio.SelectedItem as AccionPrecio;
            AccionPrecioForm page = new AccionPrecioForm(_accionPrecioService, accionPrecio);
            page.ShowDialog();
        }
        private void dgAccionPrecio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditAccionPrecio.IsEnabled = true;
            DeleteAccionPrecio.IsEnabled = true;

        }
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSearch != null)
                txtSearch.Text = string.Empty;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void DeleteAccionPrecio_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la Accion Precio?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                AccionPrecio accionPrecio = dgAccionPrecio.SelectedItem as AccionPrecio;
                if (accionPrecio != null)
                {
                    var response = _accionPrecioService.DeleteAccionPrecio(accionPrecio.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Accion Precio eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La Accion Precio se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Accion Precio no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            datagrid.ItemsSource = _accionPrecioService.FindAllAccionPrecios();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }
}
