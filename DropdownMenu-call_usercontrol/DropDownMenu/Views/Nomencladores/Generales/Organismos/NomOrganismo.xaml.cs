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

namespace DIRU.Views.Nomencladores.Generales.Organismos
{
    /// <summary>
    /// Interaction logic for NomOrganismo.xaml
    /// </summary>
    public partial class NomOrganismo : UserControl
    {
        private readonly IOrganismoService _organismoService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomOrganismo()
        {
            InitializeComponent();
            _organismoService = DependencyRegister._organismoService;

            dgOrganismo.ItemsSource = _organismoService.FindAllOrganismos();
            datagrid = dgOrganismo;
            Edit = EditOrganismo;
            Delete = DeleteOrganismo;
        }
        private void AddOrganismo_Click(object sender, RoutedEventArgs e)
        {
            OrganismoForm page = new OrganismoForm(_organismoService);
            page.ShowDialog();
        }

        private void EditOrganismo_Click(object sender, RoutedEventArgs e)
        {
            Organismo organismo = dgOrganismo.SelectedItem as Organismo;
            OrganismoForm page = new OrganismoForm(_organismoService, organismo);
            page.ShowDialog();
        }
        private void dgOrganismo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditOrganismo.IsEnabled = true;
            DeleteOrganismo.IsEnabled = true;

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
               
                default:
                    dgOrganismo.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Organismo)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgOrganismo.Items.Refresh();
                    break;

            }
        }

        private void DeleteOrganismo_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la organismo?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                Organismo organismo = dgOrganismo.SelectedItem as Organismo;
                if (organismo != null)
                {
                    var response = _organismoService.DeleteOrganismo(organismo.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Organismo eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La organismo se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Organismo no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            datagrid.ItemsSource = _organismoService.FindAllOrganismos();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }


}

