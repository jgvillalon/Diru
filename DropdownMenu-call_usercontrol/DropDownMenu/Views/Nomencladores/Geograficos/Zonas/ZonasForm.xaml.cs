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

namespace DIRU.Views.Nomencladores.Geograficos.Zonas
{
    /// <summary>
    /// Interaction logic for ZonasForm.xaml
    /// </summary>
    public partial class ZonasForm : Window
    {
        public ZonaUbicacion _zonaUbicacion;
        private readonly IZonaUbicacionService _zonaUbicacionService;
        public ZonasForm(IZonaUbicacionService zonaUbicacionService, ZonaUbicacion zonaUbicacion = null)
        {
            InitializeComponent();
            _zonaUbicacionService = zonaUbicacionService;

            if (zonaUbicacion != null)
            {
                //txtCodigoUbicacion.Text = zonaUbicacion.Codigo;
                txtNombreZona.Text = zonaUbicacion.Nombre;
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = zonaUbicacion.Active;
                _zonaUbicacion = zonaUbicacion;

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
                if (_zonaUbicacion == null)
                {
                    ZonaUbicacion newZonaUbicacion = new ZonaUbicacion
                    {
                        Active = true,
                        // Codigo = txtCodigoZonaUbicacion.Text,
                        Nombre = txtNombreZona.Text,


                    };

                    var response = _zonaUbicacionService.InsertZonaUbicacion(newZonaUbicacion);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Zona creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La zona ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var zonaUbicacion = _zonaUbicacionService.GetZonaUbicacionbyId(_zonaUbicacion.Id);
                    // zonaUbicacion.Codigo = txtCodigoZonaUbicacion.Text;
                    zonaUbicacion.Nombre = txtNombreZona.Text;
                    zonaUbicacion.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false;


                    var response = _zonaUbicacionService.UpdateZonaUbicacion(zonaUbicacion);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Zona modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomZonas.datagrid.SelectedItem = null;
            NomZonas.datagrid.ItemsSource = _zonaUbicacionService.FindAllZonaUbicacions();
            NomZonas.Edit.IsEnabled = false;
            NomZonas.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
            // txtCodigoZonaUbicacion.Text = null;
            txtNombreZona.Text = null;

        }
        private bool ValidateCampos()
        {


            if (!string.IsNullOrWhiteSpace(txtNombreZona.Text))
                return true;

            return false;
        }
    }

}


