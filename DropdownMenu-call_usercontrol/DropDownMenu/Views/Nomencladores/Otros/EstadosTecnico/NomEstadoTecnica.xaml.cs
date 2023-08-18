using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using Entity.Entitys.Nomencladores.Otros;
using Repository.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DIRU.Views.Nomencladores.Otros.EstadosTecnico
{
    /// <summary>
    /// Interaction logic for NomEstadoTecnica.xaml
    /// </summary>
    public partial class NomEstadoTecnica : UserControl
    {
        private readonly IEstadoTecnicoService _estadoTecnicoService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomEstadoTecnica()
        {
            InitializeComponent();
            _estadoTecnicoService = DependencyRegister._estadoTecnicoService;

            dgEstadoTecnico.ItemsSource = _estadoTecnicoService.FindAllEstadoTecnicos();
            datagrid = dgEstadoTecnico;
            Edit = EditEstadoTecnico;
            Delete = DeleteEstadoTecnico;
        }

        private void AddEstadoTecnico_Click(object sender, RoutedEventArgs e)
        {
            EstadoTecnicoForm page = new EstadoTecnicoForm(_estadoTecnicoService);
            page.ShowDialog();
        }

        private void EditEstadoTecnico_Click(object sender, RoutedEventArgs e)
        {
            EstadoTecnico estadoTecnico = dgEstadoTecnico.SelectedItem as EstadoTecnico;
            EstadoTecnicoForm page = new EstadoTecnicoForm(_estadoTecnicoService, estadoTecnico);
            page.ShowDialog();
        }
        private void dgEstadoTecnico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditEstadoTecnico.IsEnabled = true;
            DeleteEstadoTecnico.IsEnabled = true;

        }
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSearch != null)
                txtSearch.Text = string.Empty;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void DeleteEstadoTecnico_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la estadoTecnico?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                EstadoTecnico estadoTecnico = dgEstadoTecnico.SelectedItem as EstadoTecnico;
                if (estadoTecnico != null)
                {
                    var response = _estadoTecnicoService.DeleteEstadoTecnico(estadoTecnico.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("EstadoTecnico eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La estadoTecnico se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("EstadoTecnico no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            datagrid.ItemsSource = _estadoTecnicoService.FindAllEstadoTecnicos();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }

}

