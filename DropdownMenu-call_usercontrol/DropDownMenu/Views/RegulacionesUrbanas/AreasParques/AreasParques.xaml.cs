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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIRU.Views.RegulacionesUrbanas.AreasParques
{
    /// <summary>
    /// Interaction logic for AreasParques.xaml
    /// </summary>
    public partial class AreasParques : UserControl
    {
        private string Imagen1 = null;
        private string Imagen2 = null;
        private string Imagen3 = null;
        private string Imagen4 = null;
        private string Imagen5 = null;
        private string Imagen6 = null;
        private string Imagen7 = null;

        private AreasParquesRU AreasP = null;
        private Proyecto currentProject = null;
        private readonly IProyectoService _proyectoService;

        public AreasParquesRU AreasParquesRU { get; }

        public AreasParques()
        {
            InitializeComponent();

            _proyectoService = DependencyRegister._proyectoService;
            if (MainWindow.currentProject != null)
            {
                currentProject = MainWindow.currentProject;

                AreasParquesSearchOptions AreasParquesOptions = new AreasParquesSearchOptions();
                AreasParquesOptions.InversionLoteId = currentProject.InversionLotes.Id;

                AreasParquesRU AreasP = DependencyRegister._AreasParquesService.FindAllAreasParquess(AreasParquesOptions).FirstOrDefault();
                if (AreasP != null)
                {
                    txtParquesUrbanos.Text = AreasP.ParquesUrbanos.ToString();
                    ParquesUrbanosObservaciones.Text = AreasP.ParquesUrbanosObservacion;
                    ImageViewer1.Source = AreasP.ParquesUrbanosImagen != null ? new BitmapImage(new Uri(AreasP.ParquesUrbanosImagen, UriKind.Absolute)) : null;
                    Imagen1 = AreasP.ParquesUrbanosImagen != null ? AreasP.ParquesUrbanosImagen : null;

                    txtMicroparques.Text = AreasP.Microparques.ToString();
                    MicroparquesObservaciones.Text = AreasP.MicroparquesObservacion;
                    ImageViewer2.Source = AreasP.MicroparquesImagen != null ? new BitmapImage(new Uri(AreasP.MicroparquesImagen, UriKind.Absolute)) : null;
                    Imagen2 = AreasP.MicroparquesImagen != null ? AreasP.MicroparquesImagen : null;

                    txtPlazas.Text = AreasP.Plazas.ToString();
                    PlazasObservaciones.Text = AreasP.PlazasObservacion;
                    ImageViewer3.Source = AreasP.ImagenPlazas != null ? new BitmapImage(new Uri(AreasP.ImagenPlazas, UriKind.Absolute)) : null;
                    Imagen3 = AreasP.ImagenPlazas != null ? AreasP.ImagenPlazas : null;

                    txtArboladosAvenidas.Text = AreasP.ArboladosAvenidas.ToString();
                    ArboladosAvenidasObservaciones.Text = AreasP.ArboladosAvenidasObservacion;
                    ImageViewer4.Source = AreasP.ImagenArboladosAvenidas != null ? new BitmapImage(new Uri(AreasP.ImagenArboladosAvenidas, UriKind.Absolute)) : null;
                    Imagen4 = AreasP.ImagenArboladosAvenidas != null ? AreasP.ImagenArboladosAvenidas : null;

                    txtParquesRecreativos.Text = AreasP.ParquesRecreativos.ToString();
                    ParquesRecreativosObservaciones.Text = AreasP.ParquesRecreativosObservacion;
                    ImageViewer5.Source = AreasP.ImagenParquesRecreativos != null ? new BitmapImage(new Uri(AreasP.ImagenParquesRecreativos, UriKind.Absolute)) : null;
                    Imagen5 = AreasP.ImagenParquesRecreativos != null ? AreasP.ImagenParquesRecreativos : null;

                    txtParquesInfantiles.Text = AreasP.ParquesInfantiles.ToString();
                    ParquesInfantilesObservaciones.Text = AreasP.ParquesInfantilesObservacion;
                    ImageViewer6.Source = AreasP.ImagenParquesInfantiles != null ? new BitmapImage(new Uri(AreasP.ImagenParquesInfantiles, UriKind.Absolute)) : null;
                    Imagen6 = AreasP.ImagenParquesInfantiles != null ? AreasP.ImagenParquesInfantiles : null;

                    txtEspaciosAbiertosNaturales.Text = AreasP.EspaciosAbiertosNaturales.ToString();
                    EspaciosAbiertosNaturalesObservaciones.Text = AreasP.EspaciosAbiertosNaturalesObservacion;
                    ImageViewer7.Source = AreasP.ImagenEspaciosAbiertosNaturales != null ? new BitmapImage(new Uri(AreasP.ImagenEspaciosAbiertosNaturales, UriKind.Absolute)) : null;
                    Imagen7 = AreasP.ImagenEspaciosAbiertosNaturales != null ? AreasP.ImagenEspaciosAbiertosNaturales : null;


                    if (AreasP.ParquesUrbanosObservacion != null)
                    {
                        ObservacionesParquesUrbanos.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesParquesUrbanos.Visibility = Visibility.Hidden;

                    if (AreasP.MicroparquesObservacion != null)
                    {
                        ObservacionesMicroparques.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesMicroparques.Visibility = Visibility.Hidden;

                    if (AreasP.PlazasObservacion != null)
                    {
                        ObservacionesPlazas.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPlazas.Visibility = Visibility.Hidden;

                    if (AreasP.ArboladosAvenidasObservacion != null)
                    {
                        ObservacionesArboladosAvenidas.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesArboladosAvenidas.Visibility = Visibility.Hidden;

                    if (AreasP.ParquesRecreativosObservacion != null)
                    {
                        ObservacionesParquesRecreativos.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesParquesRecreativos.Visibility = Visibility.Hidden;

                    if (AreasP.ParquesInfantilesObservacion != null)
                    {
                        ObservacionesParquesInfantiles.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesParquesInfantiles.Visibility = Visibility.Hidden;

                    if (AreasP.EspaciosAbiertosNaturalesObservacion != null)
                    {
                        ObservacionesEspaciosAbiertosNaturales.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesEspaciosAbiertosNaturales.Visibility = Visibility.Hidden;

                    if (AreasP.MicroparquesObservacion != null)
                    {
                        ObservacionesMicroparques.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesMicroparques.Visibility = Visibility.Hidden;
                }
            }
        }

        private void BrowseParquesUrbanos_Click(object sender, RoutedEventArgs e)
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

        private void BrowseMicroparques_Click(object sender, RoutedEventArgs e)
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

        private void BrowsePlazas_Click(object sender, RoutedEventArgs e)
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

        private void BrowseArboladosAvenidas_Click(object sender, RoutedEventArgs e)
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

        private void BrowseParquesRecreativos_Click(object sender, RoutedEventArgs e)
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

        private void BrowseParquesInfantiles_Click(object sender, RoutedEventArgs e)
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

        private void BrowseEspaciosAbiertosNaturales_Click(object sender, RoutedEventArgs e)
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

        private void ObservacionParquesUrbanos_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesParquesUrbanos.Visibility == Visibility.Hidden)
            {
                ObservacionesParquesUrbanos.Visibility = Visibility.Visible;
                ParquesUrbanosObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesParquesUrbanos.Visibility = Visibility.Hidden;
                ParquesUrbanosObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionMicroparques_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesMicroparques.Visibility == Visibility.Hidden)
            {
                ObservacionesMicroparques.Visibility = Visibility.Visible;
                MicroparquesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesMicroparques.Visibility = Visibility.Hidden;
                MicroparquesObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionPlazas_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPlazas.Visibility == Visibility.Hidden)
            {
                ObservacionesPlazas.Visibility = Visibility.Visible;
                PlazasObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPlazas.Visibility = Visibility.Hidden;
                PlazasObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionArboladosAvenidas_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesArboladosAvenidas.Visibility == Visibility.Hidden)
            {
                ObservacionesArboladosAvenidas.Visibility = Visibility.Visible;
                ArboladosAvenidasObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesArboladosAvenidas.Visibility = Visibility.Hidden;
                ArboladosAvenidasObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionParquesRecreativos_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesParquesRecreativos.Visibility == Visibility.Hidden)
            {
                ObservacionesParquesRecreativos.Visibility = Visibility.Visible;
                ParquesRecreativosObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesParquesRecreativos.Visibility = Visibility.Hidden;
                ParquesRecreativosObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionParquesInfantiles_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesParquesInfantiles.Visibility == Visibility.Hidden)
            {
                ObservacionesParquesInfantiles.Visibility = Visibility.Visible;
                ParquesInfantilesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesParquesInfantiles.Visibility = Visibility.Hidden;
                ParquesInfantilesObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionEspaciosAbiertosNaturales_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesEspaciosAbiertosNaturales.Visibility == Visibility.Hidden)
            {
                ObservacionesEspaciosAbiertosNaturales.Visibility = Visibility.Visible;
                EspaciosAbiertosNaturalesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesEspaciosAbiertosNaturales.Visibility = Visibility.Hidden;
                EspaciosAbiertosNaturalesObservaciones.Text = string.Empty;
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
            if (!string.IsNullOrWhiteSpace(txtParquesUrbanos.Text) && !string.IsNullOrWhiteSpace(txtMicroparques.Text) && !string.IsNullOrWhiteSpace(txtPlazas.Text)
                && !string.IsNullOrWhiteSpace(txtArboladosAvenidas.Text) && !string.IsNullOrWhiteSpace(txtParquesRecreativos.Text) && !string.IsNullOrWhiteSpace(txtParquesInfantiles.Text)
                && !string.IsNullOrWhiteSpace(txtEspaciosAbiertosNaturales.Text))
                return true;

            return false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                AreasParquesRU newAreasParques = new AreasParquesRU
                {
                    ParquesUrbanos = float.Parse(txtParquesUrbanos.Text),
                    ParquesUrbanosObservacion = ObservacionesParquesUrbanos.Visibility == Visibility.Visible ? ParquesUrbanosObservaciones.Text : null,
                    ParquesUrbanosImagen = Imagen1,

                    Microparques = float.Parse(txtMicroparques.Text),
                    MicroparquesObservacion = ObservacionesMicroparques.Visibility == Visibility.Visible ? MicroparquesObservaciones.Text : null,
                    MicroparquesImagen = Imagen2,

                    Plazas = float.Parse(txtPlazas.Text),
                    PlazasObservacion = ObservacionesPlazas.Visibility == Visibility.Visible ? PlazasObservaciones.Text : null,
                    ImagenPlazas = Imagen3,



                    ArboladosAvenidas = float.Parse(txtArboladosAvenidas.Text),
                    ArboladosAvenidasObservacion = ObservacionesArboladosAvenidas.Visibility == Visibility.Visible ? ArboladosAvenidasObservaciones.Text : null,
                    ImagenArboladosAvenidas = Imagen4,

                    ParquesRecreativos = float.Parse(txtParquesRecreativos.Text),
                    ParquesRecreativosObservacion = ObservacionesParquesRecreativos.Visibility == Visibility.Visible ? ParquesRecreativosObservaciones.Text : null,
                    ImagenParquesRecreativos = Imagen5,

                    ParquesInfantiles = float.Parse(txtParquesInfantiles.Text),
                    ParquesInfantilesObservacion = ObservacionesParquesInfantiles.Visibility == Visibility.Visible ? ParquesInfantilesObservaciones.Text : null,
                    ImagenParquesInfantiles = Imagen6,



                    EspaciosAbiertosNaturales = float.Parse(txtEspaciosAbiertosNaturales.Text),
                    EspaciosAbiertosNaturalesObservacion = ObservacionesEspaciosAbiertosNaturales.Visibility == Visibility.Visible ? EspaciosAbiertosNaturalesObservaciones.Text : null,
                    ImagenEspaciosAbiertosNaturales = Imagen7,

                    InversionLote = currentProject.InversionLotes
                };

                Response response = null;

                if (AreasP == null)
                    response = DependencyRegister._AreasParquesService.InsertAreasParques(newAreasParques);
                else
                {
                    newAreasParques.Id = AreasP.Id;
                    response = DependencyRegister._AreasParquesService.UpdateAreasParques(newAreasParques);
                }


                if (response.Status.Equals(StatusResponse.OK))
                {
                    new MessageBoxCustom("Datos guardado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    InversionLoteView.MainInversion.Children.Clear();
                    //InversionLoteView.MainInversion.Children.Add(new UsosFunciones());
                }
                else
                    new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

    }
}
