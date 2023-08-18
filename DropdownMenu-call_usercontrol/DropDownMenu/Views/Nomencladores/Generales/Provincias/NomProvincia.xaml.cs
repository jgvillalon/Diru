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

namespace DIRU.Views.Nomencladores.Generales.Provincias
{
    /// <summary>
    /// Interaction logic for NomProvincia.xaml
    /// </summary>
    public partial class NomProvincia : UserControl
    {
        private readonly IProvinciaService _provinciaService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomProvincia()
        {
            InitializeComponent();
            _provinciaService = DependencyRegister._provinciaService;

            dgProvincia.ItemsSource = _provinciaService.FindAllProvincias();
            datagrid = dgProvincia;
            Edit = EditProvincia;
            Delete = DeleteProvincia;
        }
        private void AddProvincia_Click(object sender, RoutedEventArgs e)
        {
            ProvinciaForm page = new ProvinciaForm(_provinciaService);
            page.ShowDialog();
        }

        private void EditProvincia_Click(object sender, RoutedEventArgs e)
        {
            Provincia provincia = dgProvincia.SelectedItem as Provincia;
            ProvinciaForm page = new ProvinciaForm(_provinciaService, provincia);
            page.ShowDialog();
        }
        private void dgProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditProvincia.IsEnabled = true;
            DeleteProvincia.IsEnabled = true;

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
                case "País":
                    dgProvincia.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
                    ((Provincia)f).Pais.Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgProvincia.Items.Refresh();
                    break;
                default:
                    dgProvincia.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
                    ((Provincia)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgProvincia.Items.Refresh();
                    break;

            }
        }

        private void DeleteProvincia_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la provincia?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                Provincia provincia = dgProvincia.SelectedItem as Provincia;
                if (provincia != null)
                {
                    var response = _provinciaService.DeleteProvincia(provincia.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Provincia eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La provincia se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Provincia no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            datagrid.ItemsSource = _provinciaService.FindAllProvincias();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }


}


