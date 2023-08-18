using ApplicationService.Nomencladores.Generales.IService;
using DIRU.Dependencies;
using DIRU.Views.Nomencladores.Generales.Clientes;
using DIRU.Views.RegulacionesUrbanas;
using DropDownMenu;
using DropDownMenu.Views.InversionLotes;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos;
using NHibernate.Proxy;
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

namespace DIRU.Views.Common
{
    /// <summary>
    /// Interaction logic for DatosCliente.xaml
    /// </summary>
    public partial class DatosCliente : UserControl
    {
        private readonly IClienteService _clienteService;
        private Proyecto currentProject = null;
        private  Cliente _cliente;
        public DatosCliente()
        {
            InitializeComponent();
            _clienteService = DependencyRegister._clienteService;
            comboCliente.ItemsSource = DependencyRegister._clienteService.FindAllClientes();
            if (MainWindow.currentProject != null)
            {
                currentProject = MainWindow.currentProject;
                if (currentProject.Cliente != null)
                    comboCliente.SelectedItem = currentProject.Cliente;


            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentProject == null)
            {
                currentProject = new Proyecto
                {
                    Cliente = _cliente,
                    CreatedBy = MainWindow.currentUser,
                    CreateOn = DateTime.Now,
                    Active = true
                };


            }

            else
            {


                currentProject.Cliente = _cliente;
                currentProject.Active = true;
            }
            if (MainWindow.MainView.Children.OfType<InversionLoteView>().Count() > 0)
            {
                currentProject.Tipo = TipoProyecto.InversionLote;
                MainWindow.currentProject = currentProject;
                InversionLoteView.MainInversion.Children.Clear();
                InversionLoteView.MainInversion.Children.Add(new DatosInversion());
            }
           else if (MainWindow.MainView.Children.OfType<RegulacionUrbana>().Count() > 0)
            {
                currentProject.Tipo = TipoProyecto.RegeneracionUrbana;
                MainWindow.currentProject = currentProject;
                RegulacionUrbana.MainRegulacion.Children.Clear();
                RegulacionUrbana.MainRegulacion.Children.Add(new RegulacionUrbana());
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.MainView.Children.OfType<InversionLoteView>().Count() > 0)
                InversionLoteView.MainInversion.Children.Clear();
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

        private void ComboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            _cliente = comboCliente.SelectedItem as Cliente;
            if(_cliente != null)
            {
                txtCI.Text = _cliente.CI;
                txtCodigo.Text = _cliente.Codigo;
                txtCorreo.Text = _cliente.Correo;
                txtdireccion.Text = _cliente.Direccion;
                txtResponsable.Text = _cliente.Responsable;
                txtTelefono.Text = _cliente.Telefono;
                comboEndtidad.Text = _cliente.Entidad?.Nombre;
                if(_cliente.NaturalJuridica == false){
                    comboProvincia.Text = _cliente.Municipio?.Provincia.Nombre;
                    comboMunicipio.Text = _cliente.Municipio?.Nombre;
                }else{
                    comboProvincia.Text = _cliente.Entidad?.Municipio.Provincia.Nombre;
                    comboMunicipio.Text = _cliente.Entidad?.Municipio.Nombre;
                }

                
                comboOrganismo.Text = _cliente.Entidad?.Organismo.Nombre;
               
                BtnSave.IsEnabled = true;


            }
           
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
          new  ClientesForm(DependencyRegister._clienteService).ShowDialog();
            var clientes = _clienteService.FindAllClientes();
            comboCliente.ItemsSource = clientes;
            comboCliente.SelectedItem = clientes.LastOrDefault();
        }
    }
}
