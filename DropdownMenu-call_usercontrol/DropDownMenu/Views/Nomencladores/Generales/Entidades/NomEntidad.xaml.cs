using ApplicationService.Nomencladores.Generales.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using Entity.Entitys.Nomencladores.Generales;
using Repository.Common;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DIRU.Views.Nomencladores.Generales.Entidades
{
    /// <summary>
    /// Interaction logic for NomEntidad.xaml
    /// </summary>
    public partial class NomEntidad : UserControl
    {
        private readonly IEntidadService _entidadService;
        public static DataGrid datagrid;
        public static Button Edit;
        public static Button Delete;
        public NomEntidad()
        {
            InitializeComponent();
            _entidadService = DependencyRegister._entidadService;
           
            dgEntidad.ItemsSource = _entidadService.FindAllEntidades();
            datagrid = dgEntidad;
            Edit = EditEntidad;
            Delete = DeleteEntidad;
        }
        private void AddEntidad_Click(object sender, RoutedEventArgs e)
        {
            EntidadForm page = new EntidadForm(_entidadService);
            page.ShowDialog();
        }

        private void EditEntidad_Click(object sender, RoutedEventArgs e)
        {
            Entidad entidad = dgEntidad.SelectedItem as Entidad;
            EntidadForm page = new EntidadForm(_entidadService, entidad);
            page.ShowDialog();
        }
        private void dgEntidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditEntidad.IsEnabled = true;
            DeleteEntidad.IsEnabled = true;

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
                case "Codigo":
                    dgEntidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Entidad)f).Codigo.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgEntidad.Items.Refresh();
                    break;
                case "Organismo":
                    
                    dgEntidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Entidad)f).Organismo != null && ((Entidad)f).Organismo.Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgEntidad.Items.Refresh();
                    break;
                case "Municipio":
                    dgEntidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Entidad)f).Municipio.Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgEntidad.Items.Refresh();
                    break;
                case "Provincia":
                    dgEntidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Entidad)f).Municipio.Provincia.Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgEntidad.Items.Refresh();
                    break;
                case "País":
                    dgEntidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Entidad)f).Municipio.Provincia.Pais.Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgEntidad.Items.Refresh();
                    break;
                default:
                    dgEntidad.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Entidad)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgEntidad.Items.Refresh();
                    break;

            }
        }

        private void DeleteEntidad_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar la entidad?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {

                Entidad entidad = dgEntidad.SelectedItem as Entidad;
                if (entidad != null)
                {
                    var response = _entidadService.DeleteEntidad(entidad.Id);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        new MessageBoxCustom("Entidad eliminada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();

                    }
                    else if (response.Status.Equals(StatusResponse.InUse))
                        new MessageBoxCustom("La entidad se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else if (response.Status.Equals(StatusResponse.NotFound))
                        new MessageBoxCustom("Entidad no encontrada.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }
            }
        }
        private void gridRefresh()
        {
            datagrid.SelectedItem = null;
           datagrid.ItemsSource = _entidadService.FindAllEntidades();
            Edit.IsEnabled = false;
           Delete.IsEnabled = false;
        }
    }

  
}

