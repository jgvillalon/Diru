using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DropDownMenu;
using DropDownMenu.Views.InversionLotes;
using Entity.Entitys.Proyectos;
using MaterialDesignThemes.Wpf;
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

namespace DIRU.Views.CargarProyectos
{
    /// <summary>
    /// Interaction logic for LoadProjects.xaml
    /// </summary>
    public partial class LoadProjects : UserControl
    {
        private readonly IProyectoService _proyectoService;
        public LoadProjects()
        {
            InitializeComponent();
            _proyectoService = DependencyRegister._proyectoService;
            var proyetos = _proyectoService.FindAllProyectos();
            if (MainWindow.currentProject != null) {
                proyetos.First(p => p.Id == MainWindow.currentProject.Id).Current = true;
            }
            dgProjects.ItemsSource = proyetos;
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
                case "Tipo":
                    dgProjects.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Proyecto)f).Tipo.ToString().ToLower().Contains(txtSearch.Text.ToLower()));
                    dgProjects.Items.Refresh();
                    break;
                case "Estado":
                    dgProjects.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Proyecto)f).Estado.ToString().ToLower().Contains(txtSearch.Text.ToLower()));
                    dgProjects.Items.Refresh();
                    break;
                default:
                    dgProjects.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((Proyecto)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgProjects.Items.Refresh();
                    break;

            }
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var project = dgProjects.SelectedItem as Proyecto;
            var current = ((List<Proyecto>)(dgProjects.ItemsSource)).FirstOrDefault(p => p.Current);
            if(current != null)
            current.Current = false;
            project.Current = true;
            dgProjects.Items.Refresh();

            if (project.Tipo == TipoProyecto.InversionLote) {
                MainWindow.MainView.Children.Clear();
                MainWindow.MainView.Children.Add(new InversionLoteView());
                switch (project.Estado) {
                    case EstadoProyecto.Iniciado:
                        MainWindow.menuGenerales.IsEnabled = true;
                        break;
                    case EstadoProyecto.EnProceso:
                        MainWindow.menuGenerales.IsEnabled = true;
                        InversionLoteView.mInfGeneral.IsEnabled = true;
                        InversionLoteView.mDiagnostico.IsEnabled = true;
                        InversionLoteView.mRegulacionUrbana.IsEnabled = true;
                        InversionLoteView.mDatosDiseño.IsEnabled = true;
                        break;
                    case EstadoProyecto.Diagnosticado:
                        MainWindow.menuGenerales.IsEnabled = true;
                        InversionLoteView.mInfGeneral.IsEnabled = true;
                        InversionLoteView.mDiagnostico.IsEnabled = true;
                        InversionLoteView.mEvaluaciones.IsEnabled = true;
                        InversionLoteView.mRegulacionUrbana.IsEnabled = true;
                        InversionLoteView.mDatosDiseño.IsEnabled = true;
                        break;
                    case EstadoProyecto.EvaluandoVulnerabilidad:
                        MainWindow.menuGenerales.IsEnabled = true;
                        InversionLoteView.mInfGeneral.IsEnabled = true;
                        InversionLoteView.mDiagnostico.IsEnabled = true;
                        InversionLoteView.mEvaluaciones.IsEnabled = true;
                        InversionLoteView.mVulnerabilidad.IsEnabled = true;
                        InversionLoteView.mRegulacionUrbana.IsEnabled = true;
                        InversionLoteView.mDatosDiseño.IsEnabled = true;

                        if (!string.IsNullOrWhiteSpace(project.InversionLotes.UrlEvaluaciones))
                            InversionLoteView.mInfoAptitudPrimaria.IsEnabled = true;
                        break;
                    case EstadoProyecto.EnRegeneracionUrbana:
                        MainWindow.menuGenerales.IsEnabled = true;
                        InversionLoteView.mInfGeneral.IsEnabled = true;
                        InversionLoteView.mDiagnostico.IsEnabled = true;
                        InversionLoteView.mEvaluaciones.IsEnabled = true;
                        InversionLoteView.mVulnerabilidad.IsEnabled = true;
                        InversionLoteView.mDatosDiseño.IsEnabled = true;

                        if (!string.IsNullOrWhiteSpace(project.InversionLotes.UrlEvaluaciones))
                            InversionLoteView.mInfoAptitudPrimaria.IsEnabled = true; 
                        InversionLoteView.mRegulacionUrbana.IsEnabled = true;

                        break;
                }
                if(project.InversionLotes != null && project.InversionLotes.CantidadPlantas > 0)
                    InversionLoteView.mInmuebles.IsEnabled = true;
                if (project.InversionLotes != null && !string.IsNullOrWhiteSpace(project.InversionLotes.UrlEvaluaciones)) { 
                    InversionLoteView.mEvaluaciones.IsEnabled = true;
                    InversionLoteView.mVulnerabilidad.IsEnabled = true;
                    InversionLoteView.mInfoAptitudPrimaria.IsEnabled = true;
                }


                MainWindow.currentProject = project;
                InversionLoteView.currentProject = project;
                InversionLoteView.mProject.Header = project.Nombre;
                InversionLoteView.mProject.Icon = new PackIcon {
                    Kind=PackIconKind.FolderUpload
                };
               
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var project = dgProjects.SelectedItem as Proyecto;
            project.Active = false;
            var response = _proyectoService.UpdateProyecto(project);
            if (response.Status.Equals(StatusResponse.OK))
            {

                new MessageBoxCustom("Proyecto cancelado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                gridRefresh();
            }
            else
                new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            var project = dgProjects.SelectedItem as Proyecto;
            project.Active = true;
            var response = _proyectoService.UpdateProyecto(project);
            if (response.Status.Equals(StatusResponse.OK))
            {

                new MessageBoxCustom("Proyecto reiniciado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                gridRefresh();
            }
            else
                new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void dgProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var project = dgProjects.SelectedItem as Proyecto;
            if (project != null) {

                if (!project.Active) { 
                RestartProject.IsEnabled = true;
                CancelProject.IsEnabled = false;
                LoadProject.IsEnabled = false;
            }
            else { 
            CancelProject.IsEnabled = true;
            LoadProject.IsEnabled = true;
            RestartProject.IsEnabled = false;
            }
            }
        }
        private void gridRefresh()
        {
            dgProjects.SelectedItem = null;
            dgProjects.ItemsSource = _proyectoService.FindAllProyectos();
            RestartProject.IsEnabled = false;
            CancelProject.IsEnabled = false;
            LoadProject.IsEnabled = false;
        }
    }
}
