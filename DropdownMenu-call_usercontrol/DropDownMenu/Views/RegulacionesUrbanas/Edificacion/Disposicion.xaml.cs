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

namespace DIRU.Views.RegulacionesUrbanas.Edificacion
{
    /// <summary>
    /// Interaction logic for Disposicion.xaml
    /// </summary>
    public partial class Disposicion : UserControl
    {
        private string Imagen1 = null;
        private string Imagen2 = null;
        private string Imagen3 = null; 
        private DisposicionEdificacionRU DisposicionEdificacion = null;
        private Proyecto currentProject = null;
        private readonly IProyectoService _proyectoService;
        public Disposicion()
        {
            InitializeComponent(); 

            _proyectoService = DependencyRegister._proyectoService;

            if (MainWindow.currentProject != null)
            {
                currentProject = MainWindow.currentProject;

                DisposicionEdificacionSearchOptions DisposicionEdificacionOptions = new DisposicionEdificacionSearchOptions();
                DisposicionEdificacionOptions.InversionLoteId = currentProject.InversionLotes.Id;

                DisposicionEdificacion = DependencyRegister._DisposicionEdificacionService.FindAllDisposicionEdificacion(DisposicionEdificacionOptions).FirstOrDefault();
                if (DisposicionEdificacion != null)
                {
                    comboPermisosAbiertas.Text = DisposicionEdificacion.Abiertas.ToString();
                    AbiertasObservaciones.Text = DisposicionEdificacion.AbiertasObservaciones;
                    ImageViewer1.Source = DisposicionEdificacion.AbiertasImagen != null ? new BitmapImage(new Uri(DisposicionEdificacion.AbiertasImagen, UriKind.Absolute)) : null;
                    Imagen1 = DisposicionEdificacion.AbiertasImagen != null ? DisposicionEdificacion.AbiertasImagen : null;

                    comboPermisosSemiComp.Text = DisposicionEdificacion.SemiCompacta.ToString();
                    SemiCompactaObservaciones.Text = DisposicionEdificacion.SemiCompactaObservaciones;
                    ImageViewer2.Source = DisposicionEdificacion.SemiCompactaImagen != null ? new BitmapImage(new Uri(DisposicionEdificacion.SemiCompactaImagen, UriKind.Absolute)) : null;
                    Imagen2 = DisposicionEdificacion.SemiCompactaImagen != null ? DisposicionEdificacion.SemiCompactaImagen : null;

                    comboPermisosCompactas.Text = DisposicionEdificacion.Compactas.ToString();
                    CompactasObservaciones.Text = DisposicionEdificacion.CompactasObservaciones;
                    ImageViewer3.Source = DisposicionEdificacion.CompactasImagen != null ? new BitmapImage(new Uri(DisposicionEdificacion.CompactasImagen, UriKind.Absolute)) : null;
                    Imagen3 = DisposicionEdificacion.CompactasImagen != null ? DisposicionEdificacion.CompactasImagen : null;


                    if (DisposicionEdificacion.AbiertasObservaciones != null)
                    {
                        ObservacionesAbiertas.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesAbiertas.Visibility = Visibility.Hidden;

                    if (DisposicionEdificacion.SemiCompactaObservaciones != null)
                    {
                        ObservacionesSemiCompacta.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesSemiCompacta.Visibility = Visibility.Hidden;

                    if (DisposicionEdificacion.CompactasObservaciones != null)
                    {
                        ObservacionesCompactas.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesCompactas.Visibility = Visibility.Hidden;
                }
            }
        }

        private void BrowseAbiertas_Click(object sender, RoutedEventArgs e)
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

        private void BrowseCompactas_Click(object sender, RoutedEventArgs e)
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

        private void BrowseSemiComp_Click(object sender, RoutedEventArgs e)
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

        private void ObservacionSemiCompacta_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesSemiCompacta.Visibility == Visibility.Hidden)
            {
                ObservacionesSemiCompacta.Visibility = Visibility.Visible;
                SemiCompactaObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesSemiCompacta.Visibility = Visibility.Hidden;
                SemiCompactaObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionCompactas_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesCompactas.Visibility == Visibility.Hidden)
            {
                ObservacionesCompactas.Visibility = Visibility.Visible;
                CompactasObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesCompactas.Visibility = Visibility.Hidden;
                CompactasObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionAbiertas_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesAbiertas.Visibility == Visibility.Hidden)
            {
                ObservacionesAbiertas.Visibility = Visibility.Visible;
                AbiertasObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesAbiertas.Visibility = Visibility.Hidden;
                AbiertasObservaciones.Text = string.Empty;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.MainView.Children.OfType<InversionLoteView>().Count() > 0)
                InversionLoteView.MainInversion.Children.Clear();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                DisposicionEdificacionRU newDisposicionEdificacion = new DisposicionEdificacionRU
                {
                    Abiertas = float.Parse(comboPermisosAbiertas.Text),
                    AbiertasObservaciones = ObservacionesAbiertas.Visibility == Visibility.Visible ? AbiertasObservaciones.Text : null,
                    AbiertasImagen = Imagen1,

                    SemiCompacta = float.Parse(comboPermisosSemiComp.Text),
                    SemiCompactaObservaciones = ObservacionesSemiCompacta.Visibility == Visibility.Visible ? SemiCompactaObservaciones.Text : null,
                    SemiCompactaImagen = Imagen2,

                    Compactas = float.Parse(comboPermisosCompactas.Text),
                    CompactasObservaciones = ObservacionesCompactas.Visibility == Visibility.Visible ? CompactasObservaciones.Text : null,
                    CompactasImagen = Imagen3,

                    InversionLote = currentProject.InversionLotes
                };

                Response response = null;

                if (DisposicionEdificacion == null)
                    response = DependencyRegister._DisposicionEdificacionService.InsertDisposicionEdificacion(newDisposicionEdificacion);
                else
                {
                    newDisposicionEdificacion.Id = DisposicionEdificacion.Id;
                    response = DependencyRegister._DisposicionEdificacionService.UpdateDisposicionEdificacion(newDisposicionEdificacion);
                }


                if (response.Status.Equals(StatusResponse.OK))
                {
                    new MessageBoxCustom("Datos guardado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    InversionLoteView.MainInversion.Children.Clear();
                    InversionLoteView.MainInversion.Children.Add(new Alineacion());
                }
                else
                    new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
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
            if (!string.IsNullOrWhiteSpace(comboPermisosAbiertas.Text) && !string.IsNullOrWhiteSpace(comboPermisosSemiComp.Text) && !string.IsNullOrWhiteSpace(comboPermisosCompactas.Text) )
                return true;

            return false;
        }


    }
}
