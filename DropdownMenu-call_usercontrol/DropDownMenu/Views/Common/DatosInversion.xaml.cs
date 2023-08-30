using ApplicationService.Inversions.IService;
using ApplicationService.Nomencladores.Generales.IService;
using ApplicationService.Nomencladores.Generales.Service;
using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.Nomencladores.Generales.Clientes;
using DIRU.Views.Nomencladores.Generales.Municipios;
using DIRU.Views.Nomencladores.Generales.Provincias;
using DIRU.Views.Nomencladores.Geograficos.Zonas;
using DropDownMenu;
using DropDownMenu.Views.InversionLotes;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Geograficos;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos;
using Repository.Common;
using Repository.Nomencladores.Generales.Options;
using Repository.Nomencladores.Geograficos.Options;
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

namespace DIRU.Views.Common
{
    /// <summary>
    /// Interaction logic for DatosInversion.xaml
    /// </summary>
    public partial class DatosInversion : UserControl
    {
        private readonly Cliente _cliente;
        private readonly IProyectoService _proyectoService;
        private readonly IInversionService _inversionService;
        private  Proyecto currentProject;
        //private readonly Cliente _cliente;
        public DatosInversion()
        {
            InitializeComponent();
           
            currentProject = MainWindow.currentProject;
            MunicipioSearchOptions munOptions = new MunicipioSearchOptions { Active = true };
            comboMunicipio.ItemsSource = DependencyRegister._municipioService.FindAllMunicipios(munOptions);
            ProvinciaSearchOptions provOptions = new ProvinciaSearchOptions { Active = true };
            comboProvincia.ItemsSource = DependencyRegister._provinciaService.FindAllProvincias(provOptions);
            ZonaUbicacionSearchOptions zonaOptions = new ZonaUbicacionSearchOptions { Active = true };
            comboZona.ItemsSource = DependencyRegister._zonaUbicacionService.FindAllZonaUbicacions(zonaOptions);

            _proyectoService = DependencyRegister._proyectoService;
            _inversionService = DependencyRegister._inversionService;
            if (currentProject != null && currentProject.Inversion != null) {
                txtCircunscripcion.Text = currentProject.Inversion.Circunscripcion;
                txtCalle.Text = currentProject.Inversion.NoCalle;
                txtConsejo.Text = currentProject.Inversion.ConsejoPopular;
                //txtConstruccion.AppendText(currentProject.Inversion.ConstruccionMontaje);
                txtECalle.Text = currentProject.Inversion.ECalle;
                //txtEquipos.AppendText(currentProject.Inversion.Equipos);
                //txtOtros.AppendText(currentProject.Inversion.Otros);
                txtManzana.Text = currentProject.Inversion.Manzana;
                txtnombreInv.Text = currentProject.Inversion.NombreInversion;
                txtNombreObra.Text = currentProject.Inversion.NombreObra;
                txtReparto.Text = currentProject.Inversion.Reparto;
                ValorEstimConstruccion.Value = currentProject.Inversion.ValorEstimadoAprobadoConstruccion;
                ValorEstimEquipos.Value = currentProject.Inversion.ValorEstimadoAprobadoEquipos;
                ValorEstimOtros.Value = currentProject.Inversion.ValorEstimadoAprobadoOtros;
                ValorEstimAprobadoConstruccion.Value = currentProject.Inversion.ValorEstimadoAprobadoConstruccion;
                ValorEstimAprobadoEquipos.Value = currentProject.Inversion.ValorEstimadoAprobadoEquipos;
                ValorEstimAprobadoOtros.Value = currentProject.Inversion.ValorEstimadoAprobadoOtros;
                comboMunicipio.SelectedItem = currentProject.Inversion.Municipio; 
                comboProvincia.SelectedItem = currentProject.Inversion.Provincia; 
                comboZona.SelectedItem = currentProject.Inversion.Zona; 
               }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
          
            char[] saltosDeLinea = { '\r', '\n' };
            
            if (ValidateCampos())
            {
                if (currentProject.Inversion == null)
                {
                    Inversion inversion = new Inversion
                    {
                        Circunscripcion = txtCircunscripcion.Text,
                        ConsejoPopular = txtConsejo.Text,
                        ECalle = txtECalle.Text,
                        NoCalle = txtCalle.Text,
                        Manzana = txtManzana.Text,
                        NombreInversion = txtnombreInv.Text,
                        NombreObra = txtNombreObra.Text,
                        Reparto = txtReparto.Text,
                        Provincia = (Provincia)comboProvincia.SelectedItem,
                        Municipio = (Municipio)comboMunicipio.SelectedItem,
                        Zona = (ZonaUbicacion)comboZona.SelectedItem,

                        ValorEstimadoConstruccion = ValorEstimConstruccion.Value.HasValue ? ValorEstimConstruccion.Value.Value : 0,
                        ValorEstimadoEquipos = ValorEstimEquipos.Value.HasValue ? ValorEstimEquipos.Value.Value : 0,
                        ValorEstimadoOtros = ValorEstimOtros.Value.HasValue ? ValorEstimOtros.Value.Value : 0,
                        ValorEstimadoAprobadoConstruccion = ValorEstimAprobadoConstruccion.Value.HasValue ? ValorEstimAprobadoConstruccion.Value.Value : 0,
                        ValorEstimadoAprobadoEquipos = ValorEstimAprobadoEquipos.Value.HasValue ? ValorEstimAprobadoEquipos.Value.Value : 0,
                        ValorEstimadoAprobadoOtros = ValorEstimAprobadoOtros.Value.HasValue ? ValorEstimAprobadoOtros.Value.Value : 0,
                        
                };
                    var response = _inversionService.InsertInversion(inversion);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        currentProject.Inversion = inversion;
                        currentProject.Nombre = inversion.NombreInversion;
                        var response1 = _proyectoService.InsertProyecto(currentProject);
                        if (response1.Status.Equals(StatusResponse.OK))
                        {

                            MainWindow.currentProject = currentProject;
                            MainWindow.currentUser.LastProject = currentProject;

                            var res = DependencyRegister._userService.UpdateUser(MainWindow.currentUser);
                            if (res.Status.Equals(StatusResponse.OK))
                            {

                                new MessageBoxCustom("Proyecto iniciado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                                MainWindow.menuGenerales.IsEnabled = true;
                                if (MainWindow.MainView.Children.OfType<InversionLoteView>().Count() > 0)
                                {
                                    InversionLoteView.MainInversion.Children.Clear();
                                    InversionLoteView.MainInversion.Children.Add(new DatosGenerales());
                                }
                            }
                            else
                                new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                        }
                        else
                            new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    }



                }
                else
                {
                    var inversion = currentProject.Inversion;
                        inversion.Circunscripcion = txtCircunscripcion.Text;
                        inversion.ConsejoPopular = txtConsejo.Text;
                        inversion.ECalle = txtECalle.Text;
                        inversion.NoCalle = txtCalle.Text;
                        inversion.Manzana = txtManzana.Text;
                        inversion.NombreInversion = txtnombreInv.Text;
                        inversion.NombreObra = txtNombreObra.Text;
                        inversion.Reparto = txtReparto.Text;
                        //inversion.ValorEstimado = ValorEstim.Value.HasValue ? ValorEstim.Value.Value : 0;
                        //inversion.ValorEstimadoAprobado = ValorEstimAprobado.Value.HasValue ? ValorEstimAprobado.Value.Value : 0;
                        inversion.Provincia = (Provincia)comboProvincia.SelectedItem;
                        inversion.Municipio = (Municipio)comboMunicipio.SelectedItem;
                        inversion.Zona = (ZonaUbicacion)comboZona.SelectedItem;
                    //inversion.Equipos = new TextRange(txtEquipos.Document.ContentStart, txtEquipos.Document.ContentEnd).Text.Trim(saltosDeLinea);
                    //inversion.ConstruccionMontaje = new TextRange(txtConstruccion.Document.ContentStart, txtConstruccion.Document.ContentEnd).Text.Trim(saltosDeLinea);
                    //inversion.Otros = new TextRange(txtOtros.Document.ContentStart, txtOtros.Document.ContentEnd).Text.Trim(saltosDeLinea);
                        inversion.ValorEstimadoConstruccion = ValorEstimConstruccion.Value.HasValue ? ValorEstimConstruccion.Value.Value : 0;
                        inversion.ValorEstimadoEquipos = ValorEstimEquipos.Value.HasValue ? ValorEstimEquipos.Value.Value : 0;
                        inversion.ValorEstimadoOtros = ValorEstimOtros.Value.HasValue ? ValorEstimOtros.Value.Value : 0;
                        inversion.ValorEstimadoAprobadoConstruccion = ValorEstimAprobadoConstruccion.Value.HasValue ? ValorEstimAprobadoConstruccion.Value.Value : 0;
                        inversion.ValorEstimadoAprobadoEquipos = ValorEstimAprobadoEquipos.Value.HasValue ? ValorEstimAprobadoEquipos.Value.Value : 0;
                        inversion.ValorEstimadoAprobadoOtros = ValorEstimAprobadoOtros.Value.HasValue ? ValorEstimAprobadoOtros.Value.Value : 0;
              
                        currentProject.Inversion = inversion;
                    var response = _proyectoService.UpdateProyecto(currentProject);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        MainWindow.currentProject = currentProject;
                        MainWindow.currentUser.LastProject = currentProject;
                        new MessageBoxCustom("Datos modificados satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        MainWindow.menuGenerales.IsEnabled = true;

                        if (MainWindow.MainView.Children.OfType<InversionLoteView>().Count() > 0)
                        {
                            InversionLoteView.MainInversion.Children.Clear();
                            InversionLoteView.MainInversion.Children.Add(new DatosGenerales());
                        }


                    }

                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

                }

            }
            else new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            Mouse.OverrideCursor = null;
        }

            private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.MainView.Children.OfType<InversionLoteView>().Count() > 0)
                InversionLoteView.MainInversion.Children.Clear();
        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }
        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        private bool ValidateCampos()
        {
            if (!string.IsNullOrWhiteSpace(txtCalle.Text) /*&& !string.IsNullOrWhiteSpace(txtCircunscripcion.Text)*/
                /*&& !string.IsNullOrWhiteSpace(txtConsejo.Text)*/ && !string.IsNullOrWhiteSpace(txtECalle.Text) /*&& !string.IsNullOrWhiteSpace(txtManzana.Text)*/ &&
                !string.IsNullOrWhiteSpace(txtnombreInv.Text) && !string.IsNullOrWhiteSpace(txtNombreObra.Text) && !string.IsNullOrWhiteSpace(txtReparto.Text) &&
                ValorEstimAprobadoConstruccion.Value.HasValue && ValorEstimConstruccion.Value.HasValue && ValorEstimAprobadoEquipos.Value.HasValue && ValorEstimEquipos.Value.HasValue &&
                ValorEstimAprobadoOtros.Value.HasValue && ValorEstimOtros.Value.HasValue &&
                comboMunicipio.SelectedItem != null /*&& comboZona.SelectedItem != null*/ && comboProvincia.SelectedItem != null)
                return true;

            return false;
        }

        private void AddZona_Click(object sender, RoutedEventArgs e)
        {
            new ZonasForm(DependencyRegister._zonaUbicacionService).ShowDialog();
            var zonas = DependencyRegister._zonaUbicacionService.FindAllZonaUbicacions();
            comboZona.ItemsSource = zonas;
            comboZona.SelectedItem = zonas.LastOrDefault();
        }

        private void AddProvincia_Click(object sender, RoutedEventArgs e)
        {
            new ProvinciaForm(DependencyRegister._provinciaService).ShowDialog();
            var provincias = DependencyRegister._provinciaService.FindAllProvincias();
            comboProvincia.ItemsSource = provincias;
            comboProvincia.SelectedItem = provincias.LastOrDefault();
        }

        private void AddMunicipio_Click(object sender, RoutedEventArgs e)
        {
            new MunicipioForm(DependencyRegister._municipioService).ShowDialog();
            var municipios = DependencyRegister._municipioService.FindAllMunicipios();
            comboMunicipio.ItemsSource = municipios;
            comboMunicipio.SelectedItem = municipios.LastOrDefault();
        }

        private void comboProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var provincia = comboProvincia.SelectedItem as Provincia;
            if (provincia != null)
            {
                MunicipioSearchOptions munOptions = new MunicipioSearchOptions { Active = true, Provincia = provincia.Id };
                comboMunicipio.ItemsSource = DependencyRegister._municipioService.FindAllMunicipios(munOptions);
            }
        }
    }
}
