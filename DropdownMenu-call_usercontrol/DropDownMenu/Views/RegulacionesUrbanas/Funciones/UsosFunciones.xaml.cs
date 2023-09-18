using ApplicationService.Common;
using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
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
using System.Windows.Shapes;

namespace DIRU.Views.RegulacionesUrbanas.Funciones
{
    /// <summary>
    /// Interaction logic for UsosFunciones.xaml
    /// </summary>
    public partial class UsosFunciones : UserControl
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
        private string Imagen11 = null;
        private string Imagen12 = null;
        private string Imagen13 = null;
        private string Imagen14 = null;
        private string Imagen15 = null;
        private string Imagen16 = null;
        private string Imagen17 = null;
        private UsosFuncionesRU UsosF = null;
        private Proyecto currentProject = null;
        private readonly IProyectoService _proyectoService;

        public UsosFunciones()
        {
            InitializeComponent();
            _proyectoService = DependencyRegister._proyectoService;
            if (MainWindow.currentProject != null)
            {
                currentProject = MainWindow.currentProject;

                UsosFuncionesSearchOptions UsosFuncionesOptions = new UsosFuncionesSearchOptions();
                UsosFuncionesOptions.InversionLoteId = currentProject.InversionLotes.Id;

                UsosF = DependencyRegister._UsosFuncionesService.FindAllUsosFuncioness(UsosFuncionesOptions).FirstOrDefault();
                if (UsosF != null)
                {
                    txtResidencial.Text = UsosF.Residencial.ToString();
                    ResidencialObservaciones.Text = UsosF.ResidencialObservacion;
                    ImageViewer1.Source = UsosF.ResidencialImagen != null ? new BitmapImage(new Uri(UsosF.ResidencialImagen, UriKind.Absolute)) : null;
                    Imagen1 = UsosF.ResidencialImagen != null ? UsosF.ResidencialImagen : null;

                    txtEspaciosPublicoVerde.Text = UsosF.EspaciosPublicoVerde.ToString();
                    EspaciosPublicoVerdeObservaciones.Text = UsosF.EspaciosPublicoVerdeObservacion;
                    ImageViewer2.Source = UsosF.EspaciosPublicoVerdeImagen != null ? new BitmapImage(new Uri(UsosF.EspaciosPublicoVerdeImagen, UriKind.Absolute)) : null;
                    Imagen2 = UsosF.EspaciosPublicoVerdeImagen != null ? UsosF.EspaciosPublicoVerdeImagen : null;

                    txtAlojamiento.Text = UsosF.Alojamiento.ToString();
                    AlojamientoObservaciones.Text = UsosF.AlojamientoObservacion;
                    ImageViewer3.Source = UsosF.ImagenAlojamiento != null ? new BitmapImage(new Uri(UsosF.ImagenAlojamiento, UriKind.Absolute)) : null;
                    Imagen3 = UsosF.ImagenAlojamiento != null ? UsosF.ImagenAlojamiento : null;

                    txtAdministrativo.Text = UsosF.Administrativo.ToString();
                    AdministrativoObservaciones.Text = UsosF.AdministrativoObservacion;
                    ImageViewer4.Source = UsosF.ImagenAdministrativo != null ? new BitmapImage(new Uri(UsosF.ImagenAdministrativo, UriKind.Absolute)) : null;
                    Imagen4 = UsosF.ImagenAdministrativo != null ? UsosF.ImagenAdministrativo : null;

                    txtComercio.Text = UsosF.Comercio.ToString();
                    ComercioObservaciones.Text = UsosF.ComercioObservacion;
                    ImageViewer5.Source = UsosF.ImagenComercio != null ? new BitmapImage(new Uri(UsosF.ImagenComercio, UriKind.Absolute)) : null;
                    Imagen5 = UsosF.ImagenComercio != null ? UsosF.ImagenComercio : null;

                    txtGastronomia.Text = UsosF.Gastronomia.ToString();
                    GastronomiaObservaciones.Text = UsosF.GastronomiaObservacion;
                    ImageViewer6.Source = UsosF.ImagenGastronomia != null ? new BitmapImage(new Uri(UsosF.ImagenGastronomia, UriKind.Absolute)) : null;
                    Imagen6 = UsosF.ImagenGastronomia != null ? UsosF.ImagenGastronomia : null;

                    txtServiciosCiudad.Text = UsosF.ServiciosCiudad.ToString();
                    ServiciosCiudadObservaciones.Text = UsosF.ServiciosCiudadObservacion;
                    ImageViewer7.Source = UsosF.ImagenServiciosCiudad != null ? new BitmapImage(new Uri(UsosF.ImagenServiciosCiudad, UriKind.Absolute)) : null;
                    Imagen7 = UsosF.ImagenServiciosCiudad != null ? UsosF.ImagenServiciosCiudad : null;

                    txtServiciosBasicos.Text = UsosF.ServiciosBasicos.ToString();
                    ServiciosBasicosObservaciones.Text = UsosF.ServiciosBasicosObservacion;
                    ImageViewer8.Source = UsosF.ImagenServiciosBasicos != null ? new BitmapImage(new Uri(UsosF.ImagenServiciosBasicos, UriKind.Absolute)) : null;
                    Imagen8 = UsosF.ImagenServiciosBasicos != null ? UsosF.ImagenServiciosBasicos : null;

                    txtAlmacenesTalleresPequeños.Text = UsosF.AlmacenesTalleresPequeños.ToString();
                    AlmacenesTalleresPequeñosObservaciones.Text = UsosF.AlmacenesTalleresPequeñosObservacion;
                    ImageViewer9.Source = UsosF.ImagenAlmacenesTalleresPequeños != null ? new BitmapImage(new Uri(UsosF.ImagenAlmacenesTalleresPequeños, UriKind.Absolute)) : null;
                    Imagen9 = UsosF.ImagenAlmacenesTalleresPequeños != null ? UsosF.ImagenAlmacenesTalleresPequeños : null;


                    txtComunales.Text = UsosF.Comunales.ToString();
                    ComunalesObservaciones.Text = UsosF.ComunalesObservacion;
                    ImageViewer1.Source = UsosF.ComunalesImagen != null ? new BitmapImage(new Uri(UsosF.ComunalesImagen, UriKind.Absolute)) : null;
                    Imagen10 = UsosF.ComunalesImagen != null ? UsosF.ComunalesImagen : null;

                    txtAgriculturaUrbana.Text = UsosF.AgriculturaUrbana.ToString();
                    AgriculturaUrbanaObservaciones.Text = UsosF.AgriculturaUrbanaObservacion;
                    ImageViewer2.Source = UsosF.AgriculturaUrbanaImagen != null ? new BitmapImage(new Uri(UsosF.AgriculturaUrbanaImagen, UriKind.Absolute)) : null;
                    Imagen11 = UsosF.AgriculturaUrbanaImagen != null ? UsosF.AgriculturaUrbanaImagen : null;

                    txtEspeciales.Text = UsosF.Especiales.ToString();
                    EspecialesObservaciones.Text = UsosF.EspecialesObservacion;
                    ImageViewer3.Source = UsosF.ImagenEspeciales != null ? new BitmapImage(new Uri(UsosF.ImagenEspeciales, UriKind.Absolute)) : null;
                    Imagen12 = UsosF.ImagenEspeciales != null ? UsosF.ImagenEspeciales : null;

                    txtProduccion.Text = UsosF.Produccion.ToString();
                    ProduccionObservaciones.Text = UsosF.ProduccionObservacion;
                    ImageViewer4.Source = UsosF.ImagenProduccion != null ? new BitmapImage(new Uri(UsosF.ImagenProduccion, UriKind.Absolute)) : null;
                    Imagen13 = UsosF.ImagenProduccion != null ? UsosF.ImagenProduccion : null;

                    txtReligioso.Text = UsosF.Religioso.ToString();
                    ReligiosoObservaciones.Text = UsosF.ReligiosoObservacion;
                    ImageViewer5.Source = UsosF.ImagenReligioso != null ? new BitmapImage(new Uri(UsosF.ImagenReligioso, UriKind.Absolute)) : null;
                    Imagen14 = UsosF.ImagenReligioso != null ? UsosF.ImagenReligioso : null;

                    txtAgropecuario.Text = UsosF.Agropecuario.ToString();
                    AgropecuarioObservaciones.Text = UsosF.AgropecuarioObservacion;
                    ImageViewer6.Source = UsosF.ImagenAgropecuario != null ? new BitmapImage(new Uri(UsosF.ImagenAgropecuario, UriKind.Absolute)) : null;
                    Imagen15 = UsosF.ImagenAgropecuario != null ? UsosF.ImagenAgropecuario : null;

                    txtParqueosLotesVacios.Text = UsosF.ParqueosLotesVacios.ToString();
                    ParqueosLotesVaciosObservaciones.Text = UsosF.ParqueosLotesVaciosObservacion;
                    ImageViewer7.Source = UsosF.ImagenParqueosLotesVacios != null ? new BitmapImage(new Uri(UsosF.ImagenParqueosLotesVacios, UriKind.Absolute)) : null;
                    Imagen16 = UsosF.ImagenParqueosLotesVacios != null ? UsosF.ImagenParqueosLotesVacios : null;

                    txtParqueosConstruidos.Text = UsosF.ParqueosConstruidos.ToString();
                    ParqueosConstruidosObservaciones.Text = UsosF.ParqueosConstruidosObservacion;
                    ImageViewer8.Source = UsosF.ImagenParqueosConstruidos != null ? new BitmapImage(new Uri(UsosF.ImagenParqueosConstruidos, UriKind.Absolute)) : null;
                    Imagen17 = UsosF.ImagenParqueosConstruidos != null ? UsosF.ImagenParqueosConstruidos : null;



                    if (UsosF.ResidencialObservacion != null)
                    {
                        ObservacionesResidencial.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesResidencial.Visibility = Visibility.Hidden;

                    if (UsosF.EspaciosPublicoVerdeObservacion != null)
                    {
                        ObservacionesEspaciosPublicoVerde.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesEspaciosPublicoVerde.Visibility = Visibility.Hidden;

                    if (UsosF.AlojamientoObservacion != null)
                    {
                        ObservacionesAlojamiento.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesAlojamiento.Visibility = Visibility.Hidden;

                    if (UsosF.AdministrativoObservacion != null)
                    {
                        ObservacionesAdministrativo.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesAdministrativo.Visibility = Visibility.Hidden;

                    if (UsosF.ComercioObservacion != null)
                    {
                        ObservacionesComercio.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesComercio.Visibility = Visibility.Hidden;

                    if (UsosF.GastronomiaObservacion != null)
                    {
                        ObservacionesGastronomia.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesGastronomia.Visibility = Visibility.Hidden;

                    if (UsosF.ServiciosCiudadObservacion != null)
                    {
                        ObservacionesServiciosCiudad.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesServiciosCiudad.Visibility = Visibility.Hidden;

                    if (UsosF.ServiciosBasicosObservacion != null)
                    {
                        ObservacionesServiciosBasicos.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesServiciosBasicos.Visibility = Visibility.Hidden;

                    if (UsosF.AlmacenesTalleresPequeñosObservacion != null)
                    {
                        ObservacionesAlmacenesTalleresPequeños.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesAlmacenesTalleresPequeños.Visibility = Visibility.Hidden;

                    if (UsosF.EspaciosPublicoVerdeObservacion != null)
                    {
                        ObservacionesEspaciosPublicoVerde.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesEspaciosPublicoVerde.Visibility = Visibility.Hidden;


                    if (UsosF.ComunalesObservacion != null)
                    {
                        ObservacionesComunales.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesComunales.Visibility = Visibility.Hidden;

                    if (UsosF.AgriculturaUrbanaObservacion != null)
                    {
                        ObservacionesAgriculturaUrbana.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesAgriculturaUrbana.Visibility = Visibility.Hidden;

                    if (UsosF.EspecialesObservacion != null)
                    {
                        ObservacionesEspeciales.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesEspeciales.Visibility = Visibility.Hidden;

                    if (UsosF.ProduccionObservacion != null)
                    {
                        ObservacionesProduccion.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesProduccion.Visibility = Visibility.Hidden;

                    if (UsosF.ReligiosoObservacion != null)
                    {
                        ObservacionesReligioso.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesReligioso.Visibility = Visibility.Hidden;

                    if (UsosF.AgropecuarioObservacion != null)
                    {
                        ObservacionesAgropecuario.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesAgropecuario.Visibility = Visibility.Hidden;

                    if (UsosF.ParqueosLotesVaciosObservacion != null)
                    {
                        ObservacionesParqueosLotesVacios.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesParqueosLotesVacios.Visibility = Visibility.Hidden;

                    if (UsosF.ParqueosConstruidosObservacion != null)
                    {
                        ObservacionesParqueosConstruidos.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesParqueosConstruidos.Visibility = Visibility.Hidden;

                    if (UsosF.AgriculturaUrbanaObservacion != null)
                    {
                        ObservacionesAgriculturaUrbana.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesAgriculturaUrbana.Visibility = Visibility.Hidden;
                }
            }
        }

        private void BrowseResidencial_Click(object sender, RoutedEventArgs e)
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

        private void BrowseEspaciosPublicoVerde_Click(object sender, RoutedEventArgs e)
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

        private void BrowseAlojamiento_Click(object sender, RoutedEventArgs e)
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

        private void BrowseAdministrativo_Click(object sender, RoutedEventArgs e)
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

        private void BrowseComercio_Click(object sender, RoutedEventArgs e)
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

        private void BrowseGastronomia_Click(object sender, RoutedEventArgs e)
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

        private void BrowseServiciosCiudad_Click(object sender, RoutedEventArgs e)
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

        private void BrowseServiciosBasicos_Click(object sender, RoutedEventArgs e)
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

        private void BrowseAlmacenesTalleresPequeños_Click(object sender, RoutedEventArgs e)
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


        private void BrowseComunales_Click(object sender, RoutedEventArgs e)
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

        private void BrowseAgriculturaUrbana_Click(object sender, RoutedEventArgs e)
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
                Imagen11 = destFile;
                ImageViewer11.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseEspeciales_Click(object sender, RoutedEventArgs e)
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
                Imagen12 = destFile;
                ImageViewer12.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseProduccion_Click(object sender, RoutedEventArgs e)
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
                Imagen13 = destFile;
                ImageViewer13.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseReligioso_Click(object sender, RoutedEventArgs e)
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
                Imagen14 = destFile;
                ImageViewer14.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseAgropecuario_Click(object sender, RoutedEventArgs e)
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
                Imagen15 = destFile;
                ImageViewer15.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseParqueosLotesVacios_Click(object sender, RoutedEventArgs e)
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
                Imagen16 = destFile;
                ImageViewer16.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void BrowseParqueosConstruidos_Click(object sender, RoutedEventArgs e)
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
                Imagen17 = destFile;
                ImageViewer17.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
            }
        }

        private void ObservacionResidencial_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesResidencial.Visibility == Visibility.Hidden)
            {
                ObservacionesResidencial.Visibility = Visibility.Visible;
                ResidencialObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesResidencial.Visibility = Visibility.Hidden;
                ResidencialObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionEspaciosPublicoVerde_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesEspaciosPublicoVerde.Visibility == Visibility.Hidden)
            {
                ObservacionesEspaciosPublicoVerde.Visibility = Visibility.Visible;
                EspaciosPublicoVerdeObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesEspaciosPublicoVerde.Visibility = Visibility.Hidden;
                EspaciosPublicoVerdeObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionAlojamiento_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesAlojamiento.Visibility == Visibility.Hidden)
            {
                ObservacionesAlojamiento.Visibility = Visibility.Visible;
                AlojamientoObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesAlojamiento.Visibility = Visibility.Hidden;
                AlojamientoObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionAdministrativo_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesAdministrativo.Visibility == Visibility.Hidden)
            {
                ObservacionesAdministrativo.Visibility = Visibility.Visible;
                AdministrativoObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesAdministrativo.Visibility = Visibility.Hidden;
                AdministrativoObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionComercio_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesComercio.Visibility == Visibility.Hidden)
            {
                ObservacionesComercio.Visibility = Visibility.Visible;
                ComercioObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesComercio.Visibility = Visibility.Hidden;
                ComercioObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionGastronomia_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesGastronomia.Visibility == Visibility.Hidden)
            {
                ObservacionesGastronomia.Visibility = Visibility.Visible;
                GastronomiaObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesGastronomia.Visibility = Visibility.Hidden;
                GastronomiaObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionServiciosCiudad_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesServiciosCiudad.Visibility == Visibility.Hidden)
            {
                ObservacionesServiciosCiudad.Visibility = Visibility.Visible;
                ServiciosCiudadObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesServiciosCiudad.Visibility = Visibility.Hidden;
                ServiciosCiudadObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionServiciosBasicos_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesServiciosBasicos.Visibility == Visibility.Hidden)
            {
                ObservacionesServiciosBasicos.Visibility = Visibility.Visible;
                ServiciosBasicosObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesServiciosBasicos.Visibility = Visibility.Hidden;
                ServiciosBasicosObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionAlmacenesTalleresPequeños_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesAlmacenesTalleresPequeños.Visibility == Visibility.Hidden)
            {
                ObservacionesAlmacenesTalleresPequeños.Visibility = Visibility.Visible;
                AlmacenesTalleresPequeñosObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesAlmacenesTalleresPequeños.Visibility = Visibility.Hidden;
                AlmacenesTalleresPequeñosObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionComunales_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesComunales.Visibility == Visibility.Hidden)
            {
                ObservacionesComunales.Visibility = Visibility.Visible;
                ComunalesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesComunales.Visibility = Visibility.Hidden;
                ComunalesObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionAgriculturaUrbana_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesAgriculturaUrbana.Visibility == Visibility.Hidden)
            {
                ObservacionesAgriculturaUrbana.Visibility = Visibility.Visible;
                AgriculturaUrbanaObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesAgriculturaUrbana.Visibility = Visibility.Hidden;
                AgriculturaUrbanaObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionEspeciales_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesEspeciales.Visibility == Visibility.Hidden)
            {
                ObservacionesEspeciales.Visibility = Visibility.Visible;
                EspecialesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesEspeciales.Visibility = Visibility.Hidden;
                EspecialesObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionProduccion_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesProduccion.Visibility == Visibility.Hidden)
            {
                ObservacionesProduccion.Visibility = Visibility.Visible;
                ProduccionObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesProduccion.Visibility = Visibility.Hidden;
                ProduccionObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionReligioso_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesReligioso.Visibility == Visibility.Hidden)
            {
                ObservacionesReligioso.Visibility = Visibility.Visible;
                ReligiosoObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesReligioso.Visibility = Visibility.Hidden;
                ReligiosoObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionAgropecuario_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesAgropecuario.Visibility == Visibility.Hidden)
            {
                ObservacionesAgropecuario.Visibility = Visibility.Visible;
                AgropecuarioObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesAgropecuario.Visibility = Visibility.Hidden;
                AgropecuarioObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionParqueosLotesVacios_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesParqueosLotesVacios.Visibility == Visibility.Hidden)
            {
                ObservacionesParqueosLotesVacios.Visibility = Visibility.Visible;
                ParqueosLotesVaciosObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesParqueosLotesVacios.Visibility = Visibility.Hidden;
                ParqueosLotesVaciosObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionParqueosConstruidos_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesParqueosConstruidos.Visibility == Visibility.Hidden)
            {
                ObservacionesParqueosConstruidos.Visibility = Visibility.Visible;
                ParqueosConstruidosObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesParqueosConstruidos.Visibility = Visibility.Hidden;
                ParqueosConstruidosObservaciones.Text = string.Empty;
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
            if (!string.IsNullOrWhiteSpace(txtResidencial.Text) && !string.IsNullOrWhiteSpace(txtEspaciosPublicoVerde.Text) && !string.IsNullOrWhiteSpace(txtAlojamiento.Text)
                && !string.IsNullOrWhiteSpace(txtAdministrativo.Text) && !string.IsNullOrWhiteSpace(txtComercio.Text) && !string.IsNullOrWhiteSpace(txtGastronomia.Text)
                && !string.IsNullOrWhiteSpace(txtServiciosCiudad.Text) && !string.IsNullOrWhiteSpace(txtServiciosBasicos.Text) && !string.IsNullOrWhiteSpace(txtAlmacenesTalleresPequeños.Text)
                && !string.IsNullOrWhiteSpace(txtComunales.Text) && !string.IsNullOrWhiteSpace(txtAgriculturaUrbana.Text) && !string.IsNullOrWhiteSpace(txtEspeciales.Text)
                && !string.IsNullOrWhiteSpace(txtProduccion.Text) && !string.IsNullOrWhiteSpace(txtReligioso.Text) && !string.IsNullOrWhiteSpace(txtAgropecuario.Text)
                && !string.IsNullOrWhiteSpace(txtParqueosLotesVacios.Text) && !string.IsNullOrWhiteSpace(txtParqueosConstruidos.Text))
                return true;

            return false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                UsosFuncionesRU newUsosF = new UsosFuncionesRU
                {
                    Residencial = float.Parse(txtResidencial.Text),
                    ResidencialObservacion = ObservacionesResidencial.Visibility == Visibility.Visible ? ResidencialObservaciones.Text : null,
                    ResidencialImagen = Imagen1,

                    EspaciosPublicoVerde = float.Parse(txtEspaciosPublicoVerde.Text),
                    EspaciosPublicoVerdeObservacion = ObservacionesEspaciosPublicoVerde.Visibility == Visibility.Visible ? EspaciosPublicoVerdeObservaciones.Text : null,
                    EspaciosPublicoVerdeImagen = Imagen2,

                    Alojamiento = float.Parse(txtAlojamiento.Text),
                    AlojamientoObservacion = ObservacionesAlojamiento.Visibility == Visibility.Visible ? AlojamientoObservaciones.Text : null,
                    ImagenAlojamiento = Imagen3,



                    Administrativo = float.Parse(txtAdministrativo.Text),
                    AdministrativoObservacion = ObservacionesAdministrativo.Visibility == Visibility.Visible ? AdministrativoObservaciones.Text : null,
                    ImagenAdministrativo = Imagen4,

                    Comercio = float.Parse(txtComercio.Text),
                    ComercioObservacion = ObservacionesComercio.Visibility == Visibility.Visible ? ComercioObservaciones.Text : null,
                    ImagenComercio = Imagen5,

                    Gastronomia = float.Parse(txtGastronomia.Text),
                    GastronomiaObservacion = ObservacionesGastronomia.Visibility == Visibility.Visible ? GastronomiaObservaciones.Text : null,
                    ImagenGastronomia = Imagen6,



                    ServiciosCiudad = float.Parse(txtServiciosCiudad.Text),
                    ServiciosCiudadObservacion = ObservacionesServiciosCiudad.Visibility == Visibility.Visible ? ServiciosCiudadObservaciones.Text : null,
                    ImagenServiciosCiudad = Imagen7,

                    ServiciosBasicos = float.Parse(txtServiciosBasicos.Text),
                    ServiciosBasicosObservacion = ObservacionesServiciosBasicos.Visibility == Visibility.Visible ? ServiciosBasicosObservaciones.Text : null,
                    ImagenServiciosBasicos = Imagen8,

                    AlmacenesTalleresPequeños = float.Parse(txtAlmacenesTalleresPequeños.Text),
                    AlmacenesTalleresPequeñosObservacion = ObservacionesAlmacenesTalleresPequeños.Visibility == Visibility.Visible ? AlmacenesTalleresPequeñosObservaciones.Text : null,
                    ImagenAlmacenesTalleresPequeños = Imagen9,

                    Comunales = float.Parse(txtComunales.Text),
                    ComunalesObservacion = ObservacionesComunales.Visibility == Visibility.Visible ? ComunalesObservaciones.Text : null,
                    ComunalesImagen = Imagen10,

                    AgriculturaUrbana = float.Parse(txtAgriculturaUrbana.Text),
                    AgriculturaUrbanaObservacion = ObservacionesAgriculturaUrbana.Visibility == Visibility.Visible ? AgriculturaUrbanaObservaciones.Text : null,
                    AgriculturaUrbanaImagen = Imagen11,

                    Especiales = float.Parse(txtEspeciales.Text),
                    EspecialesObservacion = ObservacionesEspeciales.Visibility == Visibility.Visible ? EspecialesObservaciones.Text : null,
                    ImagenEspeciales = Imagen12,



                    Produccion = float.Parse(txtProduccion.Text),
                    ProduccionObservacion = ObservacionesProduccion.Visibility == Visibility.Visible ? ProduccionObservaciones.Text : null,
                    ImagenProduccion = Imagen13,

                    Religioso = float.Parse(txtReligioso.Text),
                    ReligiosoObservacion = ObservacionesReligioso.Visibility == Visibility.Visible ? ReligiosoObservaciones.Text : null,
                    ImagenReligioso = Imagen14,

                    Agropecuario = float.Parse(txtAgropecuario.Text),
                    AgropecuarioObservacion = ObservacionesAgropecuario.Visibility == Visibility.Visible ? AgropecuarioObservaciones.Text : null,
                    ImagenAgropecuario = Imagen15,



                    ParqueosLotesVacios = float.Parse(txtParqueosLotesVacios.Text),
                    ParqueosLotesVaciosObservacion = ObservacionesParqueosLotesVacios.Visibility == Visibility.Visible ? ParqueosLotesVaciosObservaciones.Text : null,
                    ImagenParqueosLotesVacios = Imagen16,

                    ParqueosConstruidos = float.Parse(txtParqueosConstruidos.Text),
                    ParqueosConstruidosObservacion = ObservacionesParqueosConstruidos.Visibility == Visibility.Visible ? ParqueosConstruidosObservaciones.Text : null,
                    ImagenParqueosConstruidos = Imagen17,


                    InversionLote = currentProject.InversionLotes
                };

                Response response = null;

                if (UsosF == null)
                    response = DependencyRegister._UsosFuncionesService.InsertUsosFunciones(newUsosF);
                else
                {
                    newUsosF.Id = UsosF.Id;
                    response = DependencyRegister._UsosFuncionesService.UpdateUsosFunciones(newUsosF);
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
    }
}
