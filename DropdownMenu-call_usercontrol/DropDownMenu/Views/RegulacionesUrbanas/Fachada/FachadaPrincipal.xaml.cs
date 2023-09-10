using ApplicationService.Common;
using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DIRU.Views.RegulacionesUrbanas.Edificacion;
using DIRU.Views.RegulacionesUrbanas.Funciones;
using DropDownMenu;
using DropDownMenu.Views.InversionLotes;
using Entity.Entitys.Proyectos;
using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using Repository.Common;
using Repository.RegulacionesUrbanas.Options;
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

namespace DIRU.Views.RegulacionesUrbanas.Fachada
{
    /// <summary>
    /// Interaction logic for FachadaPrincipal.xaml
    /// </summary>
    public partial class FachadaPrincipal : UserControl
    {
        private string Imagen1 = null;
        private string Imagen2 = null;
        private string Imagen3 = null;
        private string Imagen4 = null;
        private string Imagen5 = null;
        private string Imagen6 = null;
        private string Imagen7 = null;
        private string Imagen8 = null;
        private string Imagen9 = null;
        private FachadaPrincipalRU FachadaP= null;
        private Proyecto currentProject = null;
        private readonly IProyectoService _proyectoService;

        public FachadaPrincipal()
        {
            InitializeComponent();
            _proyectoService = DependencyRegister._proyectoService;
            if (MainWindow.currentProject != null)
            {
                currentProject = MainWindow.currentProject;

                FachadaPrincipalSearchOptions FachadaPrincipalOptions = new FachadaPrincipalSearchOptions();
                FachadaPrincipalOptions.InversionLoteId = currentProject.InversionLotes.Id;

                FachadaP = DependencyRegister._FachadaPrincipalService.FindAllFachadaPrincipals(FachadaPrincipalOptions).FirstOrDefault();
                if (FachadaP != null)
                {
                    txtPortales.Text = FachadaP.Portales.ToString();
                    PortalesObservaciones.Text = FachadaP.PortalesObservacion;
                    ImageViewer1.Source = FachadaP.PortalesImagen != null ? new BitmapImage(new Uri(FachadaP.PortalesImagen, UriKind.Absolute)) : null;
                    Imagen1 = FachadaP.PortalesImagen != null ? FachadaP.PortalesImagen : null;

                    txtCercado.Text = FachadaP.Cercado.ToString();
                    CercadoObservaciones.Text = FachadaP.CercadoObservacion;
                    ImageViewer2.Source = FachadaP.CercadoImagen != null ? new BitmapImage(new Uri(FachadaP.CercadoImagen, UriKind.Absolute)) : null;
                    Imagen2 = FachadaP.CercadoImagen != null ? FachadaP.CercadoImagen : null;

                    txtPortalPublico.Text = FachadaP.PortalPublico.ToString();
                    PortalPublicoObservaciones.Text = FachadaP.PortalPublicoObservacion;
                    ImageViewer3.Source = FachadaP.ImagenPortalPublico != null ? new BitmapImage(new Uri(FachadaP.ImagenPortalPublico, UriKind.Absolute)) : null;
                    Imagen3 = FachadaP.ImagenPortalPublico != null ? FachadaP.ImagenPortalPublico : null;

                    txtVistasLuces.Text = FachadaP.VistasLuces.ToString();
                    VistasLucesObservaciones.Text = FachadaP.VistasLucesObservacion;
                    ImageViewer4.Source = FachadaP.ImagenVistasLuces != null ? new BitmapImage(new Uri(FachadaP.ImagenVistasLuces, UriKind.Absolute)) : null;
                    Imagen4 = FachadaP.ImagenVistasLuces != null ? FachadaP.ImagenVistasLuces : null;

                    txtSalientes.Text = FachadaP.Salientes.ToString();
                    SalientesObservaciones.Text = FachadaP.SalientesObservacion;
                    ImageViewer5.Source = FachadaP.ImagenSalientes != null ? new BitmapImage(new Uri(FachadaP.ImagenSalientes, UriKind.Absolute)) : null;
                    Imagen5 = FachadaP.ImagenSalientes != null ? FachadaP.ImagenSalientes : null;

                    txtSotanosSemisotanos.Text = FachadaP.SotanosSemisotanos.ToString();
                    SotanosSemisotanosObservaciones.Text = FachadaP.SotanosSemisotanosObservacion;
                    ImageViewer6.Source = FachadaP.ImagenSotanosSemisotanos != null ? new BitmapImage(new Uri(FachadaP.ImagenSotanosSemisotanos, UriKind.Absolute)) : null;
                    Imagen6 = FachadaP.ImagenSotanosSemisotanos != null ? FachadaP.ImagenSotanosSemisotanos : null;

                    txtMedianerias.Text = FachadaP.Medianerias.ToString();
                    MedianeriasObservaciones.Text = FachadaP.MedianeriasObservacion;
                    ImageViewer7.Source = FachadaP.ImagenMedianerias != null ? new BitmapImage(new Uri(FachadaP.ImagenMedianerias, UriKind.Absolute)) : null;
                    Imagen7 = FachadaP.ImagenMedianerias != null ? FachadaP.ImagenMedianerias : null;

                    txtMarquesinasToldos.Text = FachadaP.MarquesinasToldos.ToString();
                    MarquesinasToldosObservaciones.Text = FachadaP.MarquesinasToldosObservacion;
                    ImageViewer8.Source = FachadaP.ImagenMarquesinasToldos != null ? new BitmapImage(new Uri(FachadaP.ImagenMarquesinasToldos, UriKind.Absolute)) : null;
                    Imagen8 = FachadaP.ImagenMarquesinasToldos != null ? FachadaP.ImagenMarquesinasToldos : null;

                    txtBalconesLoggiasTerrazas.Text = FachadaP.BalconesLoggiasTerrazas.ToString();
                    BalconesLoggiasTerrazasObservaciones.Text = FachadaP.BalconesLoggiasTerrazasObservacion;
                    ImageViewer9.Source = FachadaP.ImagenBalconesLoggiasTerrazas != null ? new BitmapImage(new Uri(FachadaP.ImagenBalconesLoggiasTerrazas, UriKind.Absolute)) : null;
                    Imagen9 = FachadaP.ImagenBalconesLoggiasTerrazas != null ? FachadaP.ImagenBalconesLoggiasTerrazas : null;


                    if (FachadaP.PortalesObservacion != null)
                    {
                        ObservacionesPortales.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPortales.Visibility = Visibility.Hidden;

                    if (FachadaP.CercadoObservacion != null)
                    {
                        ObservacionesCercado.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesCercado.Visibility = Visibility.Hidden;

                    if (FachadaP.PortalPublicoObservacion != null)
                    {
                        ObservacionesPortalPublico.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPortalPublico.Visibility = Visibility.Hidden;

                    if (FachadaP.VistasLucesObservacion != null)
                    {
                        ObservacionesVistasLuces.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesVistasLuces.Visibility = Visibility.Hidden;

                    if (FachadaP.SalientesObservacion != null)
                    {
                        ObservacionesSalientes.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesSalientes.Visibility = Visibility.Hidden;

                    if (FachadaP.SotanosSemisotanosObservacion != null)
                    {
                        ObservacionesSotanosSemisotanos.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesSotanosSemisotanos.Visibility = Visibility.Hidden;

                    if (FachadaP.MedianeriasObservacion != null)
                    {
                        ObservacionesMedianerias.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesMedianerias.Visibility = Visibility.Hidden;

                    if (FachadaP.MarquesinasToldosObservacion != null)
                    {
                        ObservacionesMarquesinasToldos.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesMarquesinasToldos.Visibility = Visibility.Hidden;

                    if (FachadaP.BalconesLoggiasTerrazasObservacion != null)
                    {
                        ObservacionesBalconesLoggiasTerrazas.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesBalconesLoggiasTerrazas.Visibility = Visibility.Hidden;

                    if (FachadaP.CercadoObservacion != null)
                    {
                        ObservacionesCercado.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesCercado.Visibility = Visibility.Hidden;
                }
            }
        }

        private void BrowsePortales_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen1 = destFile;
                ImageViewer1.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseCercado_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen2 = destFile;
                ImageViewer2.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowsePortalPublico_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen3 = destFile;
                ImageViewer3.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseVistasLuces_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen4 = destFile;
                ImageViewer4.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseSalientes_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen5 = destFile;
                ImageViewer5.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseSotanosSemisotanos_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen6 = destFile;
                ImageViewer6.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseMedianerias_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen7 = destFile;
                ImageViewer7.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseMarquesinasToldos_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen8 = destFile;
                ImageViewer8.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseBalconesLoggiasTerrazas_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"; // Specify the types of images which can be picked
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepath = ofd.FileName;
                var filename = filepath.Split('\\').Last();
                string targetPath = AppDomain.CurrentDomain.BaseDirectory + @"\Assets\Projects";
                string destFile = System.IO.Path.Combine(targetPath, filename);
                System.IO.File.Copy(filepath, destFile, true);
                Imagen9 = destFile;
                ImageViewer9.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void ObservacionPortales_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPortales.Visibility == Visibility.Hidden)
            {
                ObservacionesPortales.Visibility = Visibility.Visible;
                PortalesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPortales.Visibility = Visibility.Hidden;
                PortalesObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionCercado_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesCercado.Visibility == Visibility.Hidden)
            {
                ObservacionesCercado.Visibility = Visibility.Visible;
                CercadoObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesCercado.Visibility = Visibility.Hidden;
                CercadoObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionPortalPublico_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPortalPublico.Visibility == Visibility.Hidden)
            {
                ObservacionesPortalPublico.Visibility = Visibility.Visible;
                PortalPublicoObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPortalPublico.Visibility = Visibility.Hidden;
                PortalPublicoObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionVistasLuces_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesVistasLuces.Visibility == Visibility.Hidden)
            {
                ObservacionesVistasLuces.Visibility = Visibility.Visible;
                VistasLucesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesVistasLuces.Visibility = Visibility.Hidden;
                VistasLucesObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionSalientes_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesSalientes.Visibility == Visibility.Hidden)
            {
                ObservacionesSalientes.Visibility = Visibility.Visible;
                SalientesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesSalientes.Visibility = Visibility.Hidden;
                SalientesObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionSotanosSemisotanos_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesSotanosSemisotanos.Visibility == Visibility.Hidden)
            {
                ObservacionesSotanosSemisotanos.Visibility = Visibility.Visible;
                SotanosSemisotanosObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesSotanosSemisotanos.Visibility = Visibility.Hidden;
                SotanosSemisotanosObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionMedianerias_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesMedianerias.Visibility == Visibility.Hidden)
            {
                ObservacionesMedianerias.Visibility = Visibility.Visible;
                MedianeriasObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesMedianerias.Visibility = Visibility.Hidden;
                MedianeriasObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionMarquesinasToldos_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesMarquesinasToldos.Visibility == Visibility.Hidden)
            {
                ObservacionesMarquesinasToldos.Visibility = Visibility.Visible;
                MarquesinasToldosObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesMarquesinasToldos.Visibility = Visibility.Hidden;
                MarquesinasToldosObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionBalconesLoggiasTerrazas_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesBalconesLoggiasTerrazas.Visibility == Visibility.Hidden)
            {
                ObservacionesBalconesLoggiasTerrazas.Visibility = Visibility.Visible;
                BalconesLoggiasTerrazasObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesBalconesLoggiasTerrazas.Visibility = Visibility.Hidden;
                BalconesLoggiasTerrazasObservaciones.Text = string.Empty;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                FachadaPrincipalRU newFachadaPrincipal = new FachadaPrincipalRU
                {
                    Portales = float.Parse(txtPortales.Text),
                    PortalesObservacion = ObservacionesPortales.Visibility == Visibility.Visible ? PortalesObservaciones.Text : null,
                    PortalesImagen = Imagen1,

                    Cercado = float.Parse(txtCercado.Text),
                    CercadoObservacion = ObservacionesCercado.Visibility == Visibility.Visible ? CercadoObservaciones.Text : null,
                    CercadoImagen = Imagen2,

                    PortalPublico = float.Parse(txtPortalPublico.Text),
                    PortalPublicoObservacion = ObservacionesPortalPublico.Visibility == Visibility.Visible ? PortalPublicoObservaciones.Text : null,
                    ImagenPortalPublico = Imagen3,



                    VistasLuces = float.Parse(txtVistasLuces.Text),
                    VistasLucesObservacion = ObservacionesVistasLuces.Visibility == Visibility.Visible ? VistasLucesObservaciones.Text : null,
                    ImagenVistasLuces = Imagen4,

                    Salientes = float.Parse(txtSalientes.Text),
                    SalientesObservacion = ObservacionesSalientes.Visibility == Visibility.Visible ? SalientesObservaciones.Text : null,
                    ImagenSalientes = Imagen5,

                    SotanosSemisotanos = float.Parse(txtSotanosSemisotanos.Text),
                    SotanosSemisotanosObservacion = ObservacionesSotanosSemisotanos.Visibility == Visibility.Visible ? SotanosSemisotanosObservaciones.Text : null,
                    ImagenSotanosSemisotanos = Imagen6,



                    Medianerias = float.Parse(txtMedianerias.Text),
                    MedianeriasObservacion = ObservacionesMedianerias.Visibility == Visibility.Visible ? MedianeriasObservaciones.Text : null,
                    ImagenMedianerias = Imagen7,

                    MarquesinasToldos = float.Parse(txtMarquesinasToldos.Text),
                    MarquesinasToldosObservacion = ObservacionesMarquesinasToldos.Visibility == Visibility.Visible ? MarquesinasToldosObservaciones.Text : null,
                    ImagenMarquesinasToldos = Imagen8,

                    BalconesLoggiasTerrazas = float.Parse(txtBalconesLoggiasTerrazas.Text),
                    BalconesLoggiasTerrazasObservacion = ObservacionesBalconesLoggiasTerrazas.Visibility == Visibility.Visible ? BalconesLoggiasTerrazasObservaciones.Text : null,
                    ImagenBalconesLoggiasTerrazas = Imagen9,

                    InversionLote = currentProject.InversionLotes
                };

                Response response = null;

                if (FachadaP == null)
                    response = DependencyRegister._FachadaPrincipalService.InsertFachadaPrincipal(newFachadaPrincipal);
                else
                {
                    newFachadaPrincipal.Id = FachadaP.Id;
                    response = DependencyRegister._FachadaPrincipalService.UpdateFachadaPrincipal(newFachadaPrincipal);
                }


                if (response.Status.Equals(StatusResponse.OK))
                {
                    new MessageBoxCustom("Datos guardado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    InversionLoteView.MainInversion.Children.Clear();
                    InversionLoteView.MainInversion.Children.Add(new UsosFunciones());
                }
                else
                    new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
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
            if (!string.IsNullOrWhiteSpace(txtPortales.Text) && !string.IsNullOrWhiteSpace(txtCercado.Text) && !string.IsNullOrWhiteSpace(txtPortalPublico.Text)
                && !string.IsNullOrWhiteSpace(txtVistasLuces.Text) && !string.IsNullOrWhiteSpace(txtSalientes.Text) && !string.IsNullOrWhiteSpace(txtSotanosSemisotanos.Text)
                && !string.IsNullOrWhiteSpace(txtMedianerias.Text) && !string.IsNullOrWhiteSpace(txtMarquesinasToldos.Text) && !string.IsNullOrWhiteSpace(txtBalconesLoggiasTerrazas.Text))
                return true;

            return false;
        }
    }
}
