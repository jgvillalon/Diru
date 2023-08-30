using ApplicationService.Common;
using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
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
using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using DropDownMenu.Views.InversionLotes;
using DropDownMenu;
using Repository.RegulacionesUrbanas.Options;

namespace DIRU.Views.RegulacionesUrbanas.Alturas
{
    /// <summary>
    /// Interaction logic for Altura.xaml
    /// </summary>
    public partial class Altura : UserControl
    {
        private string Imagen1 = null;
        private string Imagen2 = null;
        private string Imagen3 = null;
        private string Imagen4 = null;
        private AlturaRU AlturaRU = null;
        private Proyecto currentProject = null;
        private readonly IProyectoService _proyectoService;
        public Altura()
        {
            InitializeComponent();

            _proyectoService = DependencyRegister._proyectoService;
            if (MainWindow.currentProject != null)
            {
                currentProject = MainWindow.currentProject;

                AlturaRUSearchOptions AlturaRUOptions = new AlturaRUSearchOptions();
                AlturaRUOptions.InversionLoteId = currentProject.InversionLotes.Id;

                AlturaRU = DependencyRegister._AlturaRUService.FindAllAlturaRUs(AlturaRUOptions).FirstOrDefault();
                if (AlturaRU != null)
                {
                    comboPlantaMaxNivel.Text = AlturaRU.NoMAxNiveles.ToString();
                    NoMaxNivelesObservaciones.Text = AlturaRU.ObservacionNoMAxNiveles;
                    ImageViewer1.Source = AlturaRU.UrlNoMAxNiveles != null ? new BitmapImage(new Uri(AlturaRU.UrlNoMAxNiveles, UriKind.Absolute)) : null;
                    Imagen1 = AlturaRU.UrlNoMAxNiveles != null ? AlturaRU.UrlNoMAxNiveles : null;

                    comboPlantaMinNivel.Text = AlturaRU.NoMinNiveles.ToString();
                    NoMinNivelesObservaciones.Text = AlturaRU.ObservacionNoMNiinveles;
                    ImageViewer2.Source = AlturaRU.UrlNoMinNiveles != null ? new BitmapImage(new Uri(AlturaRU.UrlNoMinNiveles, UriKind.Absolute)) : null;
                    Imagen2 = AlturaRU.UrlNoMinNiveles != null ? AlturaRU.UrlNoMinNiveles : null;

                    comboMetrosPuntalMinPB.Text = AlturaRU.PuntalMinPB.ToString();
                    PuntualMinPLantaBajaObservaciones.Text = AlturaRU.ObservacionPuntalMinPB;
                    ImageViewer3.Source = AlturaRU.UrlPuntalMinPB != null ? new BitmapImage(new Uri(AlturaRU.UrlPuntalMinPB, UriKind.Absolute)) : null;
                    Imagen3 = AlturaRU.UrlPuntalMinPB != null ? AlturaRU.UrlPuntalMinPB : null;

                    comboMetrosPuntalMinGeneral.Text = AlturaRU.PuntalMinGeneral.ToString();
                    PuntualMinGeneralObservaciones.Text = AlturaRU.ObservacionPuntalMinGeneral;
                    ImageViewer4.Source = AlturaRU.UrlPuntalMinGeneral != null ? new BitmapImage(new Uri(AlturaRU.UrlPuntalMinGeneral, UriKind.Absolute)) : null;
                    Imagen1 = AlturaRU.UrlPuntalMinGeneral != null ? AlturaRU.UrlPuntalMinGeneral : null;


                    if (AlturaRU.ObservacionNoMAxNiveles != null)
                    {
                        ObservacionesNoMaxNiveles.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesNoMaxNiveles.Visibility = Visibility.Hidden;

                    if (AlturaRU.ObservacionNoMNiinveles != null)
                    {
                        ObservacionesNoMinNiveles.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesNoMinNiveles.Visibility = Visibility.Hidden;

                    if (AlturaRU.ObservacionPuntalMinPB != null)
                    {
                        ObservacionesPuntualMinPLantaBaja.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPuntualMinPLantaBaja.Visibility = Visibility.Hidden;

                    if (AlturaRU.ObservacionPuntalMinGeneral != null)
                    {
                        ObservacionesPuntualMinGeneral.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesPuntualMinGeneral.Visibility = Visibility.Hidden;
                }
            }
        }

        private void ObservacionPuntalMinGeneral_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPuntualMinGeneral.Visibility == Visibility.Hidden)
            {
                ObservacionesPuntualMinGeneral.Visibility = Visibility.Visible;
                PuntualMinGeneralObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPuntualMinGeneral.Visibility = Visibility.Hidden;
                PuntualMinGeneralObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionPuntalMinPB_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesPuntualMinPLantaBaja.Visibility == Visibility.Hidden)
            {
                ObservacionesPuntualMinPLantaBaja.Visibility = Visibility.Visible;
                PuntualMinPLantaBajaObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesPuntualMinPLantaBaja.Visibility = Visibility.Hidden;
                PuntualMinPLantaBajaObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionMinNiveles_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesNoMinNiveles.Visibility == Visibility.Hidden)
            {
                ObservacionesNoMinNiveles.Visibility = Visibility.Visible;
                NoMinNivelesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesNoMinNiveles.Visibility = Visibility.Hidden;
                NoMinNivelesObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionMaxNiveles_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesNoMaxNiveles.Visibility == Visibility.Hidden)
            {
                ObservacionesNoMaxNiveles.Visibility = Visibility.Visible;
                NoMaxNivelesObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesNoMaxNiveles.Visibility = Visibility.Hidden;
                NoMaxNivelesObservaciones.Text = string.Empty;
            }
        }


        private void BrowseMaxNiveles_Click(object sender, RoutedEventArgs e)
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

        private void BrowseMinNiveles_Click(object sender, RoutedEventArgs e)
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

        private void BrowsePuntalMinPB_Click(object sender, RoutedEventArgs e)
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

        private void BrowsePuntalMinGeneral_Click(object sender, RoutedEventArgs e)
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                AlturaRU newAltura = new AlturaRU
                {
                    NoMAxNiveles = float.Parse(comboPlantaMaxNivel.Text),
                    ObservacionNoMAxNiveles = ObservacionesNoMaxNiveles.Visibility == Visibility.Visible ? NoMaxNivelesObservaciones.Text : null,

                    UrlNoMAxNiveles = Imagen1,

                    NoMinNiveles = float.Parse(comboPlantaMinNivel.Text),
                    ObservacionNoMNiinveles = ObservacionesNoMinNiveles.Visibility == Visibility.Visible ? NoMinNivelesObservaciones.Text : null,
                    UrlNoMinNiveles = Imagen2,

                    PuntalMinPB = float.Parse(comboMetrosPuntalMinPB.Text),
                    ObservacionPuntalMinPB = ObservacionesPuntualMinPLantaBaja.Visibility == Visibility.Visible ? PuntualMinPLantaBajaObservaciones.Text : null,
                    UrlPuntalMinPB = Imagen3,

                    PuntalMinGeneral = float.Parse(comboPlantaMinNivel.Text),
                    ObservacionPuntalMinGeneral = ObservacionesPuntualMinGeneral.Visibility == Visibility.Visible ? PuntualMinGeneralObservaciones.Text : null,
                    UrlPuntalMinGeneral = Imagen4,

                    InversionLote = currentProject.InversionLotes
                };

                Response response = null;

                if (AlturaRU == null)
                    response = DependencyRegister._AlturaRUService.InsertAlturaRU(newAltura);
                else
                {
                    newAltura.Id = AlturaRU.Id;
                    response = DependencyRegister._AlturaRUService.UpdateAlturaRU(newAltura);
                }


                if (response.Status.Equals(StatusResponse.OK))
                {
                    new MessageBoxCustom("Datos guardado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    InversionLoteView.MainInversion.Children.Clear();
                    InversionLoteView.MainInversion.Children.Add(new Altura());
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

        private bool ValidateCampos()
        {
            if (!string.IsNullOrWhiteSpace(comboPlantaMaxNivel.Text) && !string.IsNullOrWhiteSpace(comboPlantaMinNivel.Text) && !string.IsNullOrWhiteSpace(comboMetrosPuntalMinPB.Text) && !string.IsNullOrWhiteSpace(comboMetrosPuntalMinGeneral.Text))
                return true;

            return false;
        }


        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }
    }
}
