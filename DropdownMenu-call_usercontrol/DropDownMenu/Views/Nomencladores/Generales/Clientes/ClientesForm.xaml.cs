using ApplicationService.Nomencladores.Generales.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using Entity.Entitys.Nomencladores.Generales;
using HandyControl.Tools.Extension;
using Repository.Common;
using Repository.Nomencladores.Generales.Options;
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
using System.Windows.Shapes;

namespace DIRU.Views.Nomencladores.Generales.Clientes
{
    /// <summary>
    /// Interaction logic for ClientesForm.xaml
    /// </summary>
    public partial class ClientesForm : Window
    {
        
        public Cliente _cliente;
        private readonly IClienteService _clienteService;
        public ClientesForm(IClienteService clienteService, Cliente cliente = null)
        {
            InitializeComponent();
            _clienteService = clienteService;
            EntidadSearchOptions entOptions = new EntidadSearchOptions { Active = true };
            comboEndtidad.ItemsSource = DependencyRegister._entidadService.FindAllEntidades(entOptions);
            OrganismoSearchOptions orgOptions = new OrganismoSearchOptions { Active = true };
            comboOrganismo.ItemsSource = DependencyRegister._organismoService.FindAllOrganismos(orgOptions);
            MunicipioSearchOptions munOptions = new MunicipioSearchOptions { Active = true };
            comboMunicipio.ItemsSource = DependencyRegister._municipioService.FindAllMunicipios(munOptions);
            ProvinciaSearchOptions provOptions = new ProvinciaSearchOptions { Active = true };
            comboProvincia.ItemsSource = DependencyRegister._provinciaService.FindAllProvincias(provOptions);

            if (cliente != null)
            {
                if(cliente.NaturalJuridica == false)
                    Persona.IsChecked = true;

                //txtCodigoCliente.Text = cliente.Codigo;
                _cliente = cliente;
                txtCI.Text = cliente.CI;
                txtCodigo.Text = cliente.Codigo;
                txtCorreo.Text = cliente.Correo;
                txtdireccion.Text = cliente.Direccion;
                txtResponsable.Text = cliente.Responsable;
                txtTelefono.Text = cliente.Telefono;
                comboEndtidad.SelectedItem = cliente.Entidad;
                comboProvincia.SelectedItem = cliente.Municipio != null ? cliente.Municipio.Provincia : null;
                comboMunicipio.SelectedItem = cliente.Municipio;
                comboOrganismo.SelectedItem = cliente.Organismo;
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                if (_cliente == null)
                {
                    Cliente newCliente = new Cliente
                    {
                        Active = true,
                        Codigo = txtCodigo.Text,
                        Correo = txtCorreo.Text,
                        Direccion = txtdireccion.Text,
                        CI = txtCI.Text,
                        Reparto = txtCorreo.Text,
                        Telefono = txtTelefono.Text,
                        Responsable = txtResponsable.Text,
                        Entidad = (Entidad)comboEndtidad.SelectedItem,
                        Municipio = (Municipio)comboMunicipio.SelectedItem,
                        Organismo = (Organismo)comboOrganismo.SelectedItem,
                        Provincia = (Provincia)comboProvincia.SelectedItem,
                        NaturalJuridica = Empresa.IsChecked.HasValue ? Empresa.IsChecked.Value : false
                };

                    var response = _clienteService.InsertCliente(newCliente);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Cliente creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La cliente ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var cliente = _clienteService.GetClientebyId(_cliente.Id);
                    
                    cliente.Active = true;
                    cliente.Codigo = txtCodigo.Text;
                    cliente.Correo = txtCorreo.Text;
                    cliente.Direccion = txtdireccion.Text;
                    cliente.CI = txtCI.Text;
                    cliente.Reparto = txtCorreo.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.Responsable = txtResponsable.Text;
                    cliente.Entidad = (Entidad)comboEndtidad.SelectedItem;
                    cliente.Municipio = (Municipio)comboMunicipio.SelectedItem;
                    cliente.Organismo = (Organismo)comboOrganismo.SelectedItem;
                    cliente.Provincia = (Provincia)comboProvincia.SelectedItem;
                    cliente.NaturalJuridica = Empresa.IsChecked.HasValue ? Empresa.IsChecked.Value : false;


                    var response = _clienteService.UpdateCliente(cliente);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Cliente modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        this.Close();

                    }
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
            else
                new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void gridRefresh()
        {
            NomClientes.datagrid.SelectedItem = null;
            NomClientes.datagrid.ItemsSource = _clienteService.FindAllClientes();
            NomClientes.Edit.IsEnabled = false;
            NomClientes.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
            // txtCodigoCliente.Text = null;
            txtCodigo.Text = null;
            txtCorreo.Text = null;
            txtdireccion.Text = null;
            txtCI.Text = null;
            txtTelefono.Text = null;
            txtResponsable.Text = null;
            comboEndtidad.SelectedItem = null;
            comboMunicipio.SelectedItem = null;
            comboProvincia.SelectedItem = null;
            comboOrganismo.SelectedItem = null;
            

        }
        private bool ValidateCampos()
        {

            if (Empresa.IsChecked == false && !string.IsNullOrWhiteSpace(txtCorreo.Text) && !string.IsNullOrWhiteSpace(txtdireccion.Text) &&
                !string.IsNullOrWhiteSpace(txtCI.Text) && !string.IsNullOrWhiteSpace(txtTelefono.Text) && !string.IsNullOrWhiteSpace(txtResponsable.Text))
                return true;

          else if (Empresa.IsChecked == true && !string.IsNullOrWhiteSpace(txtCodigo.Text) && !string.IsNullOrWhiteSpace(txtCorreo.Text) && !string.IsNullOrWhiteSpace(txtdireccion.Text) &&
                !string.IsNullOrWhiteSpace(txtCI.Text) && !string.IsNullOrWhiteSpace(txtTelefono.Text) && !string.IsNullOrWhiteSpace(txtResponsable.Text) &&
                 comboEndtidad.SelectedItem != null)
                return true;

            return false;
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

        private void Empresa_Check(object sender, RoutedEventArgs e)
        {
            if (comboEndtidad != null) { 
            comboEndtidad.Visibility = Visibility.Visible;
            lblEntidad.Visibility = Visibility.Visible;
            }
            if (comboOrganismo != null) { 
                comboOrganismo.Visibility = Visibility.Visible;
            lblOrganismo.Visibility = Visibility.Visible;
            }
            if (txtCodigo != null) { 
                txtCodigo.Visibility = Visibility.Visible;
            lblCodigo.Visibility = Visibility.Visible;
            }
    }

        private void Individuo_Check(object sender, RoutedEventArgs e)
        {
            comboEndtidad.Visibility = Visibility.Collapsed;
            comboOrganismo.Visibility = Visibility.Collapsed;
            txtCodigo.Visibility = Visibility.Collapsed;
            lblCodigo.Visibility = Visibility.Collapsed;
            lblEntidad.Visibility = Visibility.Collapsed;
            lblOrganismo.Visibility = Visibility.Collapsed;
            //comboOrganismo.Visibility = Visibility.Collapsed; 
            //comboProvincia.Visibility = Visibility.Collapsed; 
        }

        private void comboEndtidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var entidad = comboEndtidad.SelectedItem as Entidad;
            if (entidad != null)
            {
                comboMunicipio.SelectedItem = entidad.Municipio;
                comboOrganismo.SelectedItem = entidad.Organismo;
                comboProvincia.SelectedItem = entidad.Municipio.Provincia;
            }
        }

        private void comboProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var provincia = comboProvincia.SelectedItem as Provincia;
            if (provincia != null)
            {
                MunicipioSearchOptions munOptions = new MunicipioSearchOptions { Active = true, Provincia = provincia.Id  };
                comboMunicipio.ItemsSource = DependencyRegister._municipioService.FindAllMunicipios(munOptions);
            }
        }
    }

}

