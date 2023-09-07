using ApplicationService.Common;
using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DIRU.Views.RegulacionesUrbanas.Fachada;
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

namespace DIRU.Views.RegulacionesUrbanas.Edificacion
{
    /// <summary>
    /// Interaction logic for Alineacion.xaml
    /// </summary>
    public partial class Alineacion : UserControl
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
        private string Imagen10 = null;
        private AlineacionEdificacionRU AlineacionEdificacion = null;
        private Proyecto currentProject = null;
        private readonly IProyectoService _proyectoService;

        public Alineacion()
        {
            InitializeComponent();
            _proyectoService = DependencyRegister._proyectoService;
            if (MainWindow.currentProject != null)
            {
                currentProject = MainWindow.currentProject;

                AlineacionEdificacionSearchOptions AlineacionEdificacionOptions = new AlineacionEdificacionSearchOptions();
                AlineacionEdificacionOptions.InversionLoteId = currentProject.InversionLotes.Id;

                AlineacionEdificacion = DependencyRegister._AlineacionEdificacionService.FindAllAlineacionEdificacions(AlineacionEdificacionOptions).FirstOrDefault();
                if (AlineacionEdificacion != null)
                {
                    txtPatio.Text = AlineacionEdificacion.Patio.ToString();
                    PatioObservaciones.Text = AlineacionEdificacion.PatioObservacion;
                    ImageViewer1.Source = AlineacionEdificacion.PatioImagen != null ? new BitmapImage(new Uri(AlineacionEdificacion.PatioImagen, UriKind.Absolute)) : null;
                    Imagen1 = AlineacionEdificacion.PatioImagen != null ? AlineacionEdificacion.PatioImagen : null;

                    txtFranjaJardin.Text = AlineacionEdificacion.FranjaJardin.ToString();
                    FranjaJardinObservaciones.Text = AlineacionEdificacion.FranjaJardinObservacion;
                    ImageViewer2.Source = AlineacionEdificacion.FranjaJardinImagen != null ? new BitmapImage(new Uri(AlineacionEdificacion.FranjaJardinImagen, UriKind.Absolute)) : null;
                    Imagen2 = AlineacionEdificacion.FranjaJardinImagen != null ? AlineacionEdificacion.FranjaJardinImagen : null;

                    txtAcera.Text = AlineacionEdificacion.Acera.ToString();
                    AceraObservaciones.Text = AlineacionEdificacion.AceraObservacion;
                    ImageViewer3.Source = AlineacionEdificacion.ImagenAcera != null ? new BitmapImage(new Uri(AlineacionEdificacion.ImagenAcera, UriKind.Absolute)) : null;
                    Imagen3 = AlineacionEdificacion.ImagenAcera != null ? AlineacionEdificacion.ImagenAcera : null;

                    txtPortal.Text = AlineacionEdificacion.PortalMedio.ToString();
                    PortalObservaciones.Text = AlineacionEdificacion.PortalMedioObservacion;
                    ImageViewer4.Source = AlineacionEdificacion.ImagenPortalMedio != null ? new BitmapImage(new Uri(AlineacionEdificacion.ImagenPortalMedio, UriKind.Absolute)) : null;
                    Imagen4 = AlineacionEdificacion.ImagenPortalMedio != null ? AlineacionEdificacion.ImagenPortalMedio : null;

                    txtPortalCorrido.Text = AlineacionEdificacion.PortalCorrido.ToString();
                    PortalCorridoObservaciones.Text = AlineacionEdificacion.PortalCorridoObservacion;
                    ImageViewer5.Source = AlineacionEdificacion.ImagenPortalCorrido != null ? new BitmapImage(new Uri(AlineacionEdificacion.ImagenPortalCorrido, UriKind.Absolute)) : null;
                    Imagen5 = AlineacionEdificacion.ImagenPortalCorrido != null ? AlineacionEdificacion.ImagenPortalCorrido : null;

                    txtPasilloLateral.Text = AlineacionEdificacion.PasilloLateral.ToString();
                    PasilloLateralObservaciones.Text = AlineacionEdificacion.PasilloLateralObservacion;
                    ImageViewer6.Source = AlineacionEdificacion.ImagenPasilloLateral != null ? new BitmapImage(new Uri(AlineacionEdificacion.ImagenPasilloLateral, UriKind.Absolute)) : null;
                    Imagen6 = AlineacionEdificacion.ImagenPasilloLateral != null ? AlineacionEdificacion.ImagenPasilloLateral : null;

                    txtPasilloFondo.Text = AlineacionEdificacion.PasilloFondo.ToString();
                    PasilloFondoObservaciones.Text = AlineacionEdificacion.PasilloFondoObservacion;
                    ImageViewer7.Source = AlineacionEdificacion.ImagenPasilloFondo != null ? new BitmapImage(new Uri(AlineacionEdificacion.ImagenPasilloFondo, UriKind.Absolute)) : null;
                    Imagen7 = AlineacionEdificacion.ImagenPasilloFondo != null ? AlineacionEdificacion.ImagenPasilloFondo : null;

                    txtRectangulo.Text = AlineacionEdificacion.Rectangulo.ToString();
                    RectanguloObservaciones.Text = AlineacionEdificacion.RectanguloObservacion;
                    ImageViewer8.Source = AlineacionEdificacion.ImagenRectangulo != null ? new BitmapImage(new Uri(AlineacionEdificacion.ImagenRectangulo, UriKind.Absolute)) : null;
                    Imagen8 = AlineacionEdificacion.ImagenRectangulo != null ? AlineacionEdificacion.ImagenRectangulo : null;

                    txtPatioInterior.Text = AlineacionEdificacion.PatioInterior.ToString();
                    PatioInteriorObservaciones.Text = AlineacionEdificacion.PatioInteriorObservacion;
                    ImageViewer9.Source = AlineacionEdificacion.ImagenPatioInterior != null ? new BitmapImage(new Uri(AlineacionEdificacion.ImagenPatioInterior, UriKind.Absolute)) : null;
                    Imagen9 = AlineacionEdificacion.ImagenPatioInterior != null ? AlineacionEdificacion.ImagenPatioInterior : null;

                    txtCercado.Text = AlineacionEdificacion.Cercado.ToString();
                    CercadoObservaciones.Text = AlineacionEdificacion.CercadoObservacion;
                    ImageViewer10.Source = AlineacionEdificacion.ImagenCercado != null ? new BitmapImage(new Uri(AlineacionEdificacion.ImagenCercado, UriKind.Absolute)) : null;
                    Imagen10 = AlineacionEdificacion.ImagenCercado != null ? AlineacionEdificacion.ImagenCercado : null;


                    if (AlineacionEdificacion.PatioObservacion != null)
                    {
                        ObservacionesPatio.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPatio.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.FranjaJardinObservacion != null)
                    {
                        ObservacionesFranjaJardin.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesFranjaJardin.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.AceraObservacion != null)
                    {
                        ObservacionesAcera.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesAcera.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.PortalMedioObservacion != null)
                    {
                        ObservacionesPortal.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPortal.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.PortalCorridoObservacion != null)
                    {
                        ObservacionesPortalCorrido.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPortalCorrido.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.PasilloLateralObservacion != null)
                    {
                        ObservacionesPasilloLateral.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPasilloLateral.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.PasilloFondoObservacion != null)
                    {
                        ObservacionesPasilloFondo.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPasilloFondo.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.RectanguloObservacion != null)
                    {
                        ObservacionesRectangulo.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesRectangulo.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.PatioInteriorObservacion != null)
                    {
                        ObservacionesPatioInterior.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPatioInterior.Visibility = Visibility.Hidden;

                    if (AlineacionEdificacion.CercadoObservacion != null)
                    {
                        ObservacionesCercado.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesCercado.Visibility = Visibility.Hidden;

                    
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                AlineacionEdificacionRU newAlineacionEdificacion = new AlineacionEdificacionRU
                {
                    Patio = float.Parse(txtPatio.Text),
                    PatioObservacion = ObservacionesPatio.Visibility == Visibility.Visible ? PatioObservaciones.Text : null,
                    PatioImagen = Imagen1,

                    FranjaJardin = float.Parse(txtFranjaJardin.Text),
                    FranjaJardinObservacion = ObservacionesFranjaJardin.Visibility == Visibility.Visible ? FranjaJardinObservaciones.Text : null,
                    FranjaJardinImagen = Imagen2,

                    Acera = float.Parse(txtAcera.Text),
                    AceraObservacion = ObservacionesAcera.Visibility == Visibility.Visible ? AceraObservaciones.Text : null,
                    ImagenAcera = Imagen3,



                    PortalMedio = float.Parse(txtPortal.Text),
                    PortalMedioObservacion = ObservacionesPortal.Visibility == Visibility.Visible ? PortalObservaciones.Text : null,
                    ImagenPortalMedio = Imagen4,

                    PortalCorrido = float.Parse(txtPortalCorrido.Text),
                    PortalCorridoObservacion = ObservacionesPortalCorrido.Visibility == Visibility.Visible ? PortalCorridoObservaciones.Text : null,
                    ImagenPortalCorrido = Imagen5,

                    PasilloLateral = float.Parse(txtPasilloLateral.Text),
                    PasilloLateralObservacion = ObservacionesPasilloLateral.Visibility == Visibility.Visible ? PasilloLateralObservaciones.Text : null,
                    ImagenPasilloLateral = Imagen6,



                    PasilloFondo = float.Parse(txtPasilloFondo.Text),
                    PasilloFondoObservacion = ObservacionesPasilloFondo.Visibility == Visibility.Visible ? PasilloFondoObservaciones.Text : null,
                    ImagenPasilloFondo = Imagen7,

                    Rectangulo = float.Parse(txtRectangulo.Text),
                    RectanguloObservacion = ObservacionesRectangulo.Visibility == Visibility.Visible ? RectanguloObservaciones.Text : null,
                    ImagenRectangulo = Imagen8,

                    PatioInterior = float.Parse(txtPatioInterior.Text),
                    PatioInteriorObservacion = ObservacionesPatioInterior.Visibility == Visibility.Visible ? PatioInteriorObservaciones.Text : null,
                    ImagenPatioInterior = Imagen9,


                    Cercado = float.Parse(txtCercado.Text),
                    CercadoObservacion = ObservacionesCercado.Visibility == Visibility.Visible ? CercadoObservaciones.Text : null,
                    ImagenCercado = Imagen10,


                    InversionLote = currentProject.InversionLotes
                };

                Response response = null;

                if (AlineacionEdificacion == null)
                    response = DependencyRegister._AlineacionEdificacionService.InsertAlineacionEdificacion(newAlineacionEdificacion);
                else
                {
                    newAlineacionEdificacion.Id = AlineacionEdificacion.Id;
                    response = DependencyRegister._AlineacionEdificacionService.UpdateAlineacionEdificacion(newAlineacionEdificacion);
                }


                if (response.Status.Equals(StatusResponse.OK))
                {
                    new MessageBoxCustom("Datos guardado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    InversionLoteView.MainInversion.Children.Clear();
                    InversionLoteView.MainInversion.Children.Add(new FachadaPrincipal());
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

        private void Browse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObservacionPatio_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPatio.Visibility == Visibility.Hidden)
            {
                ObservacionesPatio.Visibility = Visibility.Visible;
                PatioObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesFranjaJardin.Visibility = Visibility.Hidden;
                PatioObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionFranjaJardin_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesFranjaJardin.Visibility == Visibility.Hidden)
            {
                ObservacionesFranjaJardin.Visibility = Visibility.Visible;
                FranjaJardinObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesFranjaJardin.Visibility = Visibility.Hidden;
                FranjaJardinObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionAcera_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesAcera.Visibility == Visibility.Hidden)
            {
                ObservacionesAcera.Visibility = Visibility.Visible;
                AceraObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesAcera.Visibility = Visibility.Hidden;
                AceraObservaciones.Text = string.Empty;
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

        private void ObservacionPatioInterior_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPatioInterior.Visibility == Visibility.Hidden)
            {
                ObservacionesPatioInterior.Visibility = Visibility.Visible;
                PatioInteriorObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPatioInterior.Visibility = Visibility.Hidden;
                PatioInteriorObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionPasilloFondo_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPasilloFondo.Visibility == Visibility.Hidden)
            {
                ObservacionesPasilloFondo.Visibility = Visibility.Visible;
                PasilloFondoObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPasilloFondo.Visibility = Visibility.Hidden;
                PasilloFondoObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionPasilloLateral_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPasilloLateral.Visibility == Visibility.Hidden)
            {
                ObservacionesPasilloLateral.Visibility = Visibility.Visible;
                PasilloLateralObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPasilloLateral.Visibility = Visibility.Hidden;
                PasilloLateralObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionPortalCorrido_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPortalCorrido.Visibility == Visibility.Hidden)
            {
                ObservacionesPortalCorrido.Visibility = Visibility.Visible;
                PortalCorridoObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPortalCorrido.Visibility = Visibility.Hidden;
                PortalCorridoObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionPortal_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPortal.Visibility == Visibility.Hidden)
            {
                ObservacionesPortal.Visibility = Visibility.Visible;
                PortalObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPortal.Visibility = Visibility.Hidden;
                PortalObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionRectangulo_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesRectangulo.Visibility == Visibility.Hidden)
            {
                ObservacionesRectangulo.Visibility = Visibility.Visible;
                RectanguloObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesRectangulo.Visibility = Visibility.Hidden;
                RectanguloObservaciones.Text = string.Empty;
            }
        }


        private void BrowsePatio_Click(object sender, RoutedEventArgs e)
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

        private void BrowseFranjaJardin_Click(object sender, RoutedEventArgs e)
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

        private void BrowseAcera_Click(object sender, RoutedEventArgs e)
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

        private void BrowsePortal_Click(object sender, RoutedEventArgs e)
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

        private void BrowsePortalCorrido_Click(object sender, RoutedEventArgs e)
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
        private void BrowsePasilloLateral_Click(object sender, RoutedEventArgs e)
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

        private void BrowsePasilloFondo_Click(object sender, RoutedEventArgs e)
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

        private void BrowseRectangulo_Click(object sender, RoutedEventArgs e)
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

        private void BrowsePatioInterior_Click(object sender, RoutedEventArgs e)
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
                Imagen10 = destFile;
                ImageViewer10.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
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
            if (!string.IsNullOrWhiteSpace(txtPatio.Text) && !string.IsNullOrWhiteSpace(txtFranjaJardin.Text) && !string.IsNullOrWhiteSpace(txtAcera.Text)
                && !string.IsNullOrWhiteSpace(txtCercado.Text) && !string.IsNullOrWhiteSpace(txtPatioInterior.Text) && !string.IsNullOrWhiteSpace(txtPasilloFondo.Text)
                && !string.IsNullOrWhiteSpace(txtPasilloLateral.Text) && !string.IsNullOrWhiteSpace(txtPortalCorrido.Text) && !string.IsNullOrWhiteSpace(txtPortal.Text)
                && !string.IsNullOrWhiteSpace(txtRectangulo.Text))
                return true;

            return false;
        }
    }
}
