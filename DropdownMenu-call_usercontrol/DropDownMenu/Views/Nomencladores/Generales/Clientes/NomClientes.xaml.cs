using ApplicationService.Nomencladores.Generales.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using Entity.Entitys.Nomencladores.Generales;
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

namespace DIRU.Views.Nomencladores.Generales.Clientes
{
    /// <summary>
    /// Interaction logic for NomClientes.xaml
    /// </summary>
    public partial class NomClientes : UserControl
    {
        private readonly IClienteService _clienteService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomClientes()
        {
            InitializeComponent();
            _clienteService = DependencyRegister._clienteService;

            dgCliente.ItemsSource = _clienteService.FindAllClientes();
            datagrid = dgCliente;
            Edit = EditCliente;
            Delete = DeleteCliente;
        }

        private void AddCliente_Click(object sender, RoutedEventArgs e)
        {
            ClientesForm page = new ClientesForm(_clienteService);
            page.ShowDialog();
        }

        private void EditCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = dgCliente.SelectedItem as Cliente;
            ClientesForm page = new ClientesForm(_clienteService, cliente);
            page.ShowDialog();
        }
        private void dgCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditCliente.IsEnabled = true;
            DeleteCliente.IsEnabled = true;

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
                    dgCliente.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
                    ((Cliente)f).Responsable.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgCliente.Items.Refresh();
                    break;

            }
        }

        private void DeleteCliente_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la cliente?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                Cliente cliente = dgCliente.SelectedItem as Cliente;
                if (cliente != null)
                {
                    var response = _clienteService.DeleteCliente(cliente.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Cliente eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La cliente se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Cliente no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            datagrid.ItemsSource = _clienteService.FindAllClientes();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }


}


