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

namespace DIRU.Views.Nomencladores.Generales.Municipios
{
    /// <summary>
    /// Interaction logic for NomMunicipio.xaml
    /// </summary>
    public partial class NomMunicipio : UserControl
    {
        private readonly IMunicipioService _municipioService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomMunicipio()
        {
            InitializeComponent();
            _municipioService = DependencyRegister._municipioService;

            dgMunicipio.ItemsSource = _municipioService.FindAllMunicipios();
            datagrid = dgMunicipio;
            Edit = EditMunicipio;
            Delete = DeleteMunicipio;
        }
        private void AddMunicipio_Click(object sender, RoutedEventArgs e)
        {
            MunicipioForm page = new MunicipioForm(_municipioService);
            page.ShowDialog();
        }

        private void EditMunicipio_Click(object sender, RoutedEventArgs e)
        {
            Municipio municipio = dgMunicipio.SelectedItem as Municipio;
            MunicipioForm page = new MunicipioForm(_municipioService, municipio);
            page.ShowDialog();
        }
        private void dgMunicipio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditMunicipio.IsEnabled = true;
            DeleteMunicipio.IsEnabled = true;

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
                case "Provincia":
                    dgMunicipio.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Municipio)f).Provincia.Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgMunicipio.Items.Refresh();
                    break;
                default:
                    dgMunicipio.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Municipio)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgMunicipio.Items.Refresh();
                    break;

            }
        }

        private void DeleteMunicipio_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la municipio?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                Municipio municipio = dgMunicipio.SelectedItem as Municipio;
                if (municipio != null)
                {
                    var response = _municipioService.DeleteMunicipio(municipio.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Municipio eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La municipio se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Municipio no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            datagrid.ItemsSource = _municipioService.FindAllMunicipios();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }


}

