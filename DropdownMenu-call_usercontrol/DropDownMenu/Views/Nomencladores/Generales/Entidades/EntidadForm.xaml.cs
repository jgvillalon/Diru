using ApplicationService.Nomencladores.Generales.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DIRU.Views.Nomencladores.Generales.Entidades;
using DropDownMenu.Views.Nomencladores;
using Entity.Entitys.Nomencladores.Generales;
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

namespace DIRU.Views.Nomencladores.Generales
{
    /// <summary>
    /// Interaction logic for EntidadForm.xaml
    /// </summary>
    public partial class EntidadForm : Window
    {
       public Entidad _entidad;
        private readonly IEntidadService _entidadService;
        public EntidadForm(IEntidadService entidadService, Entidad entidad = null)
        {
            InitializeComponent();
            _entidadService = entidadService;

            OrganismoSearchOptions orgOptions = new OrganismoSearchOptions { Active = true};
            comboOrganismo.ItemsSource = DependencyRegister._organismoService.FindAllOrganismos(orgOptions);
           MunicipioSearchOptions munOptions = new MunicipioSearchOptions { Active = true };
            comboMunicipio.ItemsSource = DependencyRegister._municipioService.FindAllMunicipios(munOptions);

            if (entidad != null) {
                txtCodigoEntidad.Text = entidad.Codigo;
                txtNombreEntidad.Text = entidad.Nombre;
                comboMunicipio.SelectedItem = entidad.Municipio;
                comboOrganismo.SelectedItem = entidad.Organismo;
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = entidad.Active;
                _entidad = entidad;
               
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
                if (_entidad == null)
                {
                    Entidad newEntidad = new Entidad
                    {
                        Active = true,
                        Codigo = txtCodigoEntidad.Text,
                        Nombre = txtNombreEntidad.Text,
                        Organismo = (Organismo)comboOrganismo.SelectedItem,
                        Municipio = (Municipio)comboMunicipio.SelectedItem
                    };

                    var response = _entidadService.InsertEntidad(newEntidad);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Entidad creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La entidad ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var entidad = _entidadService.GetEntidadbyId(_entidad.Id);
                    entidad.Codigo = txtCodigoEntidad.Text;
                    entidad.Nombre = txtNombreEntidad.Text;
                    entidad.Municipio = (Municipio)comboMunicipio.SelectedItem;
                    entidad.Organismo = (Organismo)comboOrganismo.SelectedItem;
                    entidad.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false; 
                    

                    var response = _entidadService.UpdateEntidad(entidad);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Entidad modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomEntidad.datagrid.SelectedItem = null;
            NomEntidad.datagrid.ItemsSource = _entidadService.FindAllEntidades();
            NomEntidad.Edit.IsEnabled = false;
            NomEntidad.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
            txtCodigoEntidad.Text = null;
            txtNombreEntidad.Text = null;
            comboMunicipio.Text = null;
            comboOrganismo.Text = null;
            
           
        }
        private bool ValidateCampos()
        {
          

            if (!string.IsNullOrWhiteSpace(txtCodigoEntidad.Text) && !string.IsNullOrWhiteSpace(txtNombreEntidad.Text) && comboMunicipio.SelectedItem != null)
                return true;

            return false;
        }
    }

}
