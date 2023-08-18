using ApplicationService.Nomencladores.Generales.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
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

namespace DIRU.Views.Nomencladores.Generales.Municipios
{
    /// <summary>
    /// Interaction logic for MunicipioForm.xaml
    /// </summary>
    public partial class MunicipioForm : Window
    {
        public Municipio _municipio;
        private readonly IMunicipioService _municipioService;
        public MunicipioForm(IMunicipioService municipioService, Municipio municipio = null)
        {
            InitializeComponent();
            _municipioService = municipioService;
            ProvinciaSearchOptions provOptions = new ProvinciaSearchOptions { Active = true };
            comboProvincia.ItemsSource = DependencyRegister._provinciaService.FindAllProvincias(provOptions);

            if (municipio != null)
            {
                comboProvincia.SelectedItem = municipio.Provincia;
                txtNombreMunicipio.Text = municipio.Nombre;
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = municipio.Active;
                _municipio = municipio;

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
                if (_municipio == null)
                {
                    Municipio newMunicipio = new Municipio
                    {
                        Active = true,
                        Nombre = txtNombreMunicipio.Text,
                        Provincia = (Provincia)comboProvincia.SelectedItem
                        
                    };

                    var response = _municipioService.InsertMunicipio(newMunicipio);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Municipio creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La municipio ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var municipio = _municipioService.GetMunicipiobyId(_municipio.Id);
                    municipio.Provincia = (Provincia)comboProvincia.SelectedItem;
                    municipio.Nombre = txtNombreMunicipio.Text;
                    municipio.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false;

                    var response = _municipioService.UpdateMunicipio(municipio);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Municipio modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomMunicipio.datagrid.SelectedItem = null;
            NomMunicipio.datagrid.ItemsSource = _municipioService.FindAllMunicipios();
            NomMunicipio.Edit.IsEnabled = false;
            NomMunicipio.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
            comboProvincia.Text = null;
            txtNombreMunicipio.Text = null;

        }
        private bool ValidateCampos()
        {


            if (!string.IsNullOrWhiteSpace(txtNombreMunicipio.Text))
                return true;

            return false;
        }
    }

}
