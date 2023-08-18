using ApplicationService.Nomencladores.Geograficos.IService;
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
using System.Windows.Shapes;

namespace DIRU.Views.Nomencladores.Geograficos.Ubicaciones
{
    /// <summary>
    /// Interaction logic for UbicacionesForm.xaml
    /// </summary>
    public partial class UbicacionesForm : Window
    {
        public UbicacionGeografica _ubicacionGeografica;
        private readonly IUbicacionGeograficaService _ubicacionGeograficaService;
        public UbicacionesForm(IUbicacionGeograficaService ubicacionGeograficaService, UbicacionGeografica ubicacionGeografica = null)
        {
            InitializeComponent();
            _ubicacionGeograficaService = ubicacionGeograficaService;

            if (ubicacionGeografica != null)
            {
                //txtCodigoUbicacion.Text = ubicacionGeografica.Codigo;
                txtNombreUbicacion.Text = ubicacionGeografica.Nombre;
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = ubicacionGeografica.Active;
                _ubicacionGeografica = ubicacionGeografica;
               

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
                if (_ubicacionGeografica == null)
                {
                    UbicacionGeografica newUbicacionGeografica = new UbicacionGeografica
                    {
                        Active = true,
                       // Codigo = txtCodigoUbicacionGeografica.Text,
                        Nombre = txtNombreUbicacion.Text


                    };

                    var response = _ubicacionGeograficaService.InsertUbicacionGeografica(newUbicacionGeografica);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("UbicacionGeografica creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La ubicacionGeografica ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var ubicacionGeografica = _ubicacionGeograficaService.GetUbicacionGeograficabyId(_ubicacionGeografica.Id);
                   // ubicacionGeografica.Codigo = txtCodigoUbicacionGeografica.Text;
                    ubicacionGeografica.Nombre = txtNombreUbicacion.Text;
                    ubicacionGeografica.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false;


                    var response = _ubicacionGeograficaService.UpdateUbicacionGeografica(ubicacionGeografica);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("UbicacionGeografica modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomUbicaciones.datagrid.SelectedItem = null;
            NomUbicaciones.datagrid.ItemsSource = _ubicacionGeograficaService.FindAllUbicacionGeograficas();
            NomUbicaciones.Edit.IsEnabled = false;
            NomUbicaciones.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
           // txtCodigoUbicacionGeografica.Text = null;
            txtNombreUbicacion.Text = null;

        }
        private bool ValidateCampos()
        {


            if (!string.IsNullOrWhiteSpace(txtNombreUbicacion.Text))
                return true;

            return false;
        }
    }

}

