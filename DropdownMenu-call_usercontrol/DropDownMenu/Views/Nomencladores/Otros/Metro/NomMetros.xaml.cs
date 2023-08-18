using System;
using System.Collections.Generic;
using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using Entity.Entitys.Nomencladores.Otros;
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

namespace DIRU.Views.Nomencladores.Otros.Metro
{
    /// <summary>
    /// Interaction logic for NomMetros.xaml
    /// </summary>
    public partial class NomMetros : UserControl
    {
        private readonly IMetrosService _metrosService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomMetros()
        {
            InitializeComponent();
            _metrosService = DependencyRegister._metrosService;

            dgMetros.ItemsSource = _metrosService.FindAllMetros();
            datagrid = dgMetros;
            Edit = EditMetros;
            Delete = DeleteMetros;
        }
        private void AddMetros_Click(object sender, RoutedEventArgs e)
        {
            MetrosForm page = new MetrosForm(_metrosService);
            page.ShowDialog();
        }

        private void EditMetros_Click(object sender, RoutedEventArgs e)
        {
            Metros metros = dgMetros.SelectedItem as Metros;
            MetrosForm page = new MetrosForm(_metrosService, metros);
            page.ShowDialog();
        }
        private void dgMetros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditMetros.IsEnabled = true;
            DeleteMetros.IsEnabled = true;

        }
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSearch != null)
                txtSearch.Text = string.Empty;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
    //        switch (comboFilter.Text)
    //        {

    //            default:
    //                dgMetros.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    //((Metros)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
    //                dgMetros.Items.Refresh();
    //                break;

    //        }
        }

        private void DeleteMetros_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la ubicacion?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                Metros metros = dgMetros.SelectedItem as Metros;
                if (metros != null)
                {
                    var response = _metrosService.DeleteMetros(metros.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Metros eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La ubicacion se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Metros no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
            datagrid.ItemsSource = _metrosService.FindAllMetros();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }
    }


}

