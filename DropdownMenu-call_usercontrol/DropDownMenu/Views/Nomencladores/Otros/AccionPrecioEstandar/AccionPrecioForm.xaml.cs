using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Views.Common;
using DIRU.Views.Nomencladores.Otros.EstadosTecnico;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
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

namespace DIRU.Views.Nomencladores.Otros.AccionPrecioEstandar
{
    /// <summary>
    /// Interaction logic for AccionPrecioForm.xaml
    /// </summary>
    public partial class AccionPrecioForm : Window
    {
        public AccionPrecio _accionPrecio;
        private readonly IAccionPrecioService _accionPrecioService;
        public AccionPrecioForm(IAccionPrecioService accionPrecioService, AccionPrecio accionPrecio = null)
        {
            InitializeComponent();
            _accionPrecioService = accionPrecioService;

            var acciones = Enum.GetValues(typeof(AccionLocal)).Cast<AccionLocal>().ToList();
            comboAcciones.ItemsSource = acciones;

            if (accionPrecio != null)
            {
                precioBueno.Value = accionPrecio.PrecioBueno;
                precioRegular.Value = accionPrecio.PrecioRegular;
                precioMalo.Value = accionPrecio.PrecioMalo;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                if (_accionPrecio == null)
                {
                    AccionPrecio newAccionPrecio = new AccionPrecio
                    {
                        Active = true,
                        Accion = (AccionLocal) comboAcciones.SelectedItem,
                        PrecioBueno = precioBueno.Value.Value,
                        PrecioMalo = precioMalo.Value.Value,
                        PrecioRegular = precioRegular.Value.Value,
                    };

                    var response = _accionPrecioService.InsertAccionPrecio(newAccionPrecio);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("AccionPrecio creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La accionPrecio ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var accionPrecio = _accionPrecioService.GetAccionPreciobyId(_accionPrecio.Id);
                    accionPrecio.Accion = (AccionLocal)comboAcciones.SelectedItem;
                    accionPrecio.PrecioBueno = precioBueno.Value.Value;
                    accionPrecio.PrecioMalo = precioMalo.Value.Value;
                    accionPrecio.PrecioRegular = precioRegular.Value.Value;
                   accionPrecio.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false;

                    var response = _accionPrecioService.UpdateAccionPrecio(accionPrecio);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("AccionPrecio modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomAccionPrecio.datagrid.SelectedItem = null;
            NomAccionPrecio.datagrid.ItemsSource = _accionPrecioService.FindAllAccionPrecios();
            NomAccionPrecio.Edit.IsEnabled = false;
            NomAccionPrecio.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
            comboAcciones.SelectedItem = null;
            precioBueno.Value = (decimal)0.1;
            precioMalo.Value = (decimal)0.1;
            precioRegular.Value = (decimal)0.1;
         

        }
        private bool ValidateCampos()
        {


            if (comboAcciones.SelectedItem != null && precioBueno.Value.HasValue && precioRegular.Value.HasValue
                && precioMalo.Value.HasValue)
                return true;

            return false;
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

