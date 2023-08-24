using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.InversionLotes.Diagnostico;
using DIRU.Views.RegulacionesUrbanas;
using DropDownMenu;
using DropDownMenu.Views.InversionLotes;
using Entity.Entitys.Nomencladores.Geograficos;
using Entity.Entitys.Proyectos;
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
using Entity.Entitys.Proyectos.InversionesLotes;
using Entity.Entitys.Nomencladores.Otros;
using ApplicationService.Nomencladores.Otros.IService;
using Repository.Nomencladores.Otros.Options;

namespace DIRU.Views.Common
{
    /// <summary>
    /// Interaction logic for DatosGenerales.xaml
    /// </summary>
    public partial class DatosGenerales : UserControl
    {
        private readonly IProyectoService _proyectoService;
        private readonly IRedService _redService;
        private Proyecto currentProject = null;
        public DatosGenerales()
        {
            InitializeComponent();
            _proyectoService = DependencyRegister._proyectoService;
            _redService = DependencyRegister._redService;
             comboUbicacion.ItemsSource = DependencyRegister._ubicacionGeograficaService.FindAllUbicacionGeograficas();
             comboZona.ItemsSource = DependencyRegister._zonaUbicacionService.FindAllZonaUbicacions();
            if (MainWindow.currentProject != null) {
                currentProject = MainWindow.currentProject;
                Title.Text = "Datos Generales de "+ currentProject.Nombre;

                CantSuperficie.Value = currentProject.SuperficieTotal;
                CantArea.Value = currentProject.AreaOcupada;
                comboZona.SelectedItem = currentProject.ZonaUbicacion;
                comboUbicacion.SelectedItem = currentProject.UbicacionGeografica;
                if(currentProject.InversionLotes != null)
                    CantPlantas.Value = currentProject.InversionLotes.CantidadPlantas;
                if(!string.IsNullOrWhiteSpace(currentProject.UrlImage))
                    ImageViewer1.Source = new BitmapImage(new Uri(currentProject.UrlImage, UriKind.Absolute));


                //Redes
                if (MainWindow.currentProject.InversionLotes.Redes.Any()){
                    rBCRSi.IsChecked = true;

                    foreach (var red in MainWindow.currentProject.InversionLotes.Redes)
                    {
                        if (red.Nombre == "Red Sanitaria")
                            RSanitaria.IsChecked = true;
                        else if (red.Nombre == "Red Drenaje")
                            RDrenaje.IsChecked = true;
                        else if (red.Nombre == "Red Eléctrica")
                            RElectrica.IsChecked = true;
                        else if (red.Nombre == "Red Telefónica")
                            RTelefonica.IsChecked = true;
                        else if (red.Nombre == "Red Hidraúlica")
                            RHidraulica.IsChecked = true;
                        else if (red.Nombre == "Red Gas")
                            RGas.IsChecked = true;
                    }
                }
                else
                    rBCRNo.IsChecked = true;

            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateCampos())
                {

                    currentProject.SuperficieTotal = CantSuperficie.Value.Value;
                    currentProject.AreaOcupada = CantArea.Value.Value;
                    currentProject.ZonaUbicacion = (ZonaUbicacion)comboZona.SelectedItem;
                    currentProject.UbicacionGeografica = (UbicacionGeografica)comboUbicacion.SelectedItem;
                    if (currentProject.InversionLotes != null)
                    {
                        currentProject.InversionLotes.CantidadPlantas = CantPlantas.Value.Value;
                    }
                    else
                    {
                        currentProject.InversionLotes = new InversionLote { CantidadPlantas = CantPlantas.Value.Value };
                    }



                    currentProject.Estado = EstadoProyecto.EnProceso;
                    var response = _proyectoService.UpdateProyecto(currentProject);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        MainWindow.currentProject = currentProject;

                        // Redes
                        if (rBCRSi.IsChecked == true)
                        {
                            currentProject.InversionLotes.RemoveAllRedes();

                            RedSearchOptions RedSearchOption = new RedSearchOptions();

                            if (RSanitaria.IsChecked == true) {
                                RedSearchOption.Nombre = RSanitaria.Content.ToString();
                                var red = _redService.FindAllReds(RedSearchOption).FirstOrDefault();

                                currentProject.InversionLotes.AddRed(red);
                            }
                            if (RDrenaje.IsChecked == true) {
                                RedSearchOption.Nombre = RDrenaje.Content.ToString();
                                var red = _redService.FindAllReds(RedSearchOption).FirstOrDefault();

                                currentProject.InversionLotes.AddRed(red);
                            }

                            if (RElectrica.IsChecked == true) {
                                RedSearchOption.Nombre = RElectrica.Content.ToString();
                                var red = _redService.FindAllReds(RedSearchOption).FirstOrDefault();

                                currentProject.InversionLotes.AddRed(red);
                            }

                            if (RTelefonica.IsChecked == true) {
                                RedSearchOption.Nombre = RTelefonica.Content.ToString();
                                var red = _redService.FindAllReds(RedSearchOption).FirstOrDefault();

                                currentProject.InversionLotes.AddRed(red);
                            }

                            if (RHidraulica.IsChecked == true)
                            {
                                RedSearchOption.Nombre = RHidraulica.Content.ToString();
                                var red = _redService.FindAllReds(RedSearchOption).FirstOrDefault();

                                currentProject.InversionLotes.AddRed(red);
                            }
                            if (RGas.IsChecked == true) {
                                RedSearchOption.Nombre = RGas.Content.ToString();
                                var red = _redService.FindAllReds(RedSearchOption).FirstOrDefault();

                                currentProject.InversionLotes.AddRed(red);
                            }
                        }

                        //plantas

                        if (currentProject.InversionLotes.Plantas == null || !currentProject.InversionLotes.Plantas.Any())
                        {
                            for (int i = 0; i < currentProject.InversionLotes.CantidadPlantas; i++)
                            {
                                currentProject.InversionLotes.AddPlanta(new Planta
                                {
                                    Descripcion = i == 0 ? "Planta Baja" : "Planta No." + i
                                });
                            }
                        }

                        else
                        {
                            int PlantasCount = CantPlantas.Value.Value - currentProject.InversionLotes.Plantas.Count;
                            if (PlantasCount < 0)
                            {
                                bool? Result = new MessageBoxCustom("Se sobrescribirán las plantas ¿Está seguro? ", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

                                if (Result.Value)
                                {
                                    currentProject.InversionLotes.RemoveAllPlantas();

                                    for (int i = 0; i < currentProject.InversionLotes.CantidadPlantas; i++)
                                    {
                                        currentProject.InversionLotes.AddPlanta(new Planta
                                        {
                                            Descripcion = i == 0 ? "Planta Baja" : "Planta No." + i
                                        });
                                    }
                                }

                            }
                            else if (PlantasCount > 0 && currentProject.InversionLotes.Plantas.Any())
                            {
                                var count = currentProject.InversionLotes.Plantas.Count;
                                for (int i = 0; i < PlantasCount; i++)
                                {

                                    currentProject.InversionLotes.AddPlanta(new Planta
                                    {

                                        Descripcion = "Planta No." + count
                                    });
                                    count++;
                                }

                            }
                        }

                        _proyectoService.UpdateProyecto(currentProject);
                        new MessageBoxCustom("Datos modificados satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();

                        if (MainWindow.MainView.Children.OfType<InversionLoteView>().Count() > 0)
                        {
                            InversionLoteView.mDiagnostico.IsEnabled = true;
                            InversionLoteView.mRegulacionUrbana.IsEnabled = true;
                            InversionLoteView.mDatosDiseño.IsEnabled = true;
                            InversionLoteView.mInfGeneral.IsEnabled = true;
                            if (currentProject.InversionLotes.CantidadPlantas > 0)
                                InversionLoteView.mInmuebles.IsEnabled = true;
                            InversionLoteView.MainInversion.Children.Clear();
                            InversionLoteView.MainInversion.Children.Add(new Diagnosticos(currentProject, _proyectoService));

                        }
                        else if (MainWindow.MainView.Children.OfType<RegulacionUrbana>().Count() > 0)
                        {
                            RegulacionUrbana.mAltura.IsEnabled = true;
                            RegulacionUrbana.mAreas.IsEnabled = true;
                            RegulacionUrbana.mEdificacion.IsEnabled = true;
                            RegulacionUrbana.mEstructura.IsEnabled = true;
                            RegulacionUrbana.mFachada.IsEnabled = true;
                            RegulacionUrbana.mFunciones.IsEnabled = true;
                            RegulacionUrbana.mPlantas.IsEnabled = true;

                        }
                        else
                        {
                            InversionLoteView.mDiagnostico.IsEnabled = false;
                        }

                    }
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();


                }
                else new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            catch (Exception ex) {
                ex.GetBaseException();
            }
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
            if (CantArea.Value.HasValue && CantSuperficie.Value.HasValue && CantPlantas.Value.HasValue
                && !string.IsNullOrWhiteSpace(comboUbicacion.Text) && !string.IsNullOrWhiteSpace(comboZona.Text) 
              )
                return true;

            return false;
        }
        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory+@"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                currentProject.UrlImage = destFile;
                ImageViewer1.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            // Cargar la imagen desde un archivo
           // BitmapImage image = new BitmapImage(new Uri("ruta de la imagen"));

            // Crear una nueva instancia de la ventana ImageViewerWindow
            ImageViewerWindow imageViewerWindow = new ImageViewerWindow();

            // Establecer la propiedad ImageSource de la ventana con la imagen cargada
            imageViewerWindow.ImageSource = image.Source;

            // Mostrar la ventana ImageViewerWindow
            imageViewerWindow.ShowDialog();
        }
        private void imgViewer_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageViewer1.Opacity = 0.5;
            ImageViewer1.Cursor = Cursors.Hand;
            iconMagnify.Visibility = Visibility.Visible;
        }

        private void imgViewer_MouseLeave(object sender, MouseEventArgs e)
        {
            ImageViewer1.Opacity = 1;
            ImageViewer1.Cursor = Cursors.Arrow;
            iconMagnify.Visibility = Visibility.Collapsed;
        }

        private void Redes_Check(object sender, RoutedEventArgs e)
        {
            if (RedesTipoPanel != null)
                RedesTipoPanel.Visibility= Visibility.Visible;
        }

        private void NoRedes_Check(object sender, RoutedEventArgs e)
        {
            if(RedesTipoPanel != null)
            RedesTipoPanel.Visibility = Visibility.Collapsed;
        }
    }
}
