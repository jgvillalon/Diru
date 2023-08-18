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

namespace DIRU.Views.Nomencladores.Generales.Provincias
{
    /// <summary>
    /// Interaction logic for ProvinciaForm.xaml
    /// </summary>
    public partial class ProvinciaForm : Window
    {
        public Provincia _provincia;
        private readonly IProvinciaService _provinciaService;
        public ProvinciaForm(IProvinciaService provinciaService, Provincia provincia = null)
        {
            InitializeComponent();
            _provinciaService = provinciaService;
            PaisSearchOptions paisOptions = new PaisSearchOptions { Active = true };
            comboPais.ItemsSource = DependencyRegister._paisService.FindAllPaises(paisOptions);
            if (provincia != null)
            {
                comboPais.SelectedItem = provincia.Pais;
                txtNombreProvincia.Text = provincia.Nombre;
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = provincia.Active;
                _provincia = provincia;

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
                if (_provincia == null)
                {
                    Provincia newProvincia = new Provincia
                    {
                        Active = true,
                        Nombre = txtNombreProvincia.Text,
                        Pais = (Pais)comboPais.SelectedItem,


                    };

                    var response = _provinciaService.InsertProvincia(newProvincia);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Provincia creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La provincia ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var provincia = _provinciaService.GetProvinciabyId(_provincia.Id);
                    provincia.Nombre = txtNombreProvincia.Text;
                    provincia.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false;
                    provincia.Pais = (Pais)comboPais.SelectedItem;


                    var response = _provinciaService.UpdateProvincia(provincia);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Provincia modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomProvincia.datagrid.SelectedItem = null;
            NomProvincia.datagrid.ItemsSource = _provinciaService.FindAllProvincias();
            NomProvincia.Edit.IsEnabled = false;
            NomProvincia.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
            comboPais.Text = null;
            txtNombreProvincia.Text = null;

        }
        private bool ValidateCampos()
        {
            if (comboPais.SelectedItem != null && !string.IsNullOrWhiteSpace(txtNombreProvincia.Text))
                return true;

            return false;
        }
    }

}
