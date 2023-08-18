using ApplicationService.Nomencladores.Generales.IService;
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
using System.Windows.Shapes;

namespace DIRU.Views.Nomencladores.Generales.Organismos
{
    /// <summary>
    /// Interaction logic for OrganismoForm.xaml
    /// </summary>
    public partial class OrganismoForm : Window
    {
        public Organismo _organismo;
        private readonly IOrganismoService _organismoService;
        public OrganismoForm(IOrganismoService organismoService, Organismo organismo = null)
        {
            InitializeComponent();
            _organismoService = organismoService;

            if (organismo != null)
            {
                //txtCodigoOrganismo.Text = organismo.Codigo;
                txtNombreOrganismo.Text = organismo.Nombre;
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = organismo.Active;
                _organismo = organismo;

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
                if (_organismo == null)
                {
                    Organismo newOrganismo = new Organismo
                    {
                        Active = true,
                      
                        Nombre = txtNombreOrganismo.Text,


                    };

                    var response = _organismoService.InsertOrganismo(newOrganismo);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Organismo creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La organismo ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var organismo = _organismoService.GetOrganismobyId(_organismo.Id);
                   // organismo.Codigo = txtCodigoOrganismo.Text;
                    organismo.Nombre = txtNombreOrganismo.Text;
                    organismo.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false;


                    var response = _organismoService.UpdateOrganismo(organismo);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Organismo modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomOrganismo.datagrid.SelectedItem = null;
            NomOrganismo.datagrid.ItemsSource = _organismoService.FindAllOrganismos();
            NomOrganismo.Edit.IsEnabled = false;
            NomOrganismo.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
           // txtCodigoOrganismo.Text = null;
            txtNombreOrganismo.Text = null;

        }
        private bool ValidateCampos()
        {


            if (!string.IsNullOrWhiteSpace(txtNombreOrganismo.Text))
                return true;

            return false;
        }
    }

}

