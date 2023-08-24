using DIRU.Dependencies;
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
using Entity.Entitys.Proyectos.InversionesLotes;
using Entity.Entitys.Proyectos;
using ApplicationService.Proyectos.IService;
using DropDownMenu;
using DIRU.Views.Common;
using Repository.Common;
using DropDownMenu.Views.InversionLotes;
using DIRU.Views.RegulacionesUrbanas.Alturas;
using Repository.RegulacionesUrbanas.Options;
using ApplicationService.Common;

namespace DIRU.Views.RegulacionesUrbanas.Estructura
{
    /// <summary>
    /// Interaction logic for EstructuraManzana.xaml
    /// </summary>
    public partial class EstructuraManzana : UserControl
    {
        private string Imagen1 = null;
        private string Imagen2 = null;
        private Estructuras Estructura = null;
        private Proyecto currentProject = null; 
        private readonly IProyectoService _proyectoService;
        public EstructuraManzana()
        {
            InitializeComponent();
            _proyectoService = DependencyRegister._proyectoService;
            if (MainWindow.currentProject != null)
            {
                currentProject = MainWindow.currentProject;

                EstructuraSearchOptions EstructuraOptions = new EstructuraSearchOptions();
                EstructuraOptions.InversionLoteId = currentProject.InversionLotes.Id;

                Estructura = DependencyRegister._EstructuraService.FindAllEstructuras(EstructuraOptions).FirstOrDefault();
                if (Estructura != null) {
                    txtNoZona.Text = Estructura.NoEstructura;
                    txtMaxOcupacion.Text = Estructura.MaximaOcupacion;
                    txtMOObservaciones.Text = Estructura.MaximaOcupacionObservaciones;
                    ImageViewer1.Source = Estructura.MaximaOcupacionImagen != null ? new BitmapImage(new Uri(Estructura.MaximaOcupacionImagen, UriKind.Absolute)) : null;
                    Imagen1 = Estructura.MaximaOcupacionImagen != null ? Estructura.MaximaOcupacionImagen : null;
                    txtMinOcupacion.Text = Estructura.MinimaOcupacion;
                    txtMinOObservaciones.Text = Estructura.MinimaOcupacionObservaciones;
                    ImageViewer2.Source = Estructura.MinimaOcupacionImagen != null ? new BitmapImage(new Uri(Estructura.MinimaOcupacionImagen, UriKind.Absolute)) : null;
                    Imagen2 = Estructura.MinimaOcupacionImagen != null ? Estructura.MinimaOcupacionImagen : null;

                    if (Estructura.MaximaOcupacionObservaciones != null) {
                        ObservacionesMax.Visibility = Visibility.Visible;
                    }else
                        ObservacionesMax.Visibility = Visibility.Hidden;

                    if (Estructura.MinimaOcupacionObservaciones != null)
                    {
                        ObservacionesMin.Visibility = Visibility.Visible;
                    }
                    else
                        ObservacionesMin.Visibility = Visibility.Hidden;
                }
            } 
        }

        private void ObservacionMin_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesMin.Visibility == Visibility.Hidden)
            {
                ObservacionesMin.Visibility = Visibility.Visible;
                txtMinOObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesMin.Visibility = Visibility.Hidden;
                txtMinOObservaciones.Text = string.Empty;
            }
        }

        private void ObservacionMax_Click(object sender, RoutedEventArgs e)
        {
            if (ObservacionesMax.Visibility == Visibility.Hidden)
            {
                ObservacionesMax.Visibility = Visibility.Visible;
                txtMOObservaciones.Text = string.Empty;
            }
            else
            {
                ObservacionesMax.Visibility = Visibility.Hidden;
                txtMOObservaciones.Text = string.Empty;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateCampos())
                {
                    Estructuras newEstructura = new Estructuras
                    {
                        NoEstructura = txtNoZona.Text,
                        MaximaOcupacion = txtMaxOcupacion.Text,
                        MaximaOcupacionImagen = Imagen1,
                        MaximaOcupacionObservaciones = ObservacionesMax.Visibility == Visibility.Visible ? txtMOObservaciones.Text : null,
                        MinimaOcupacion = txtMinOcupacion.Text,
                        MinimaOcupacionImagen = Imagen2,
                        MinimaOcupacionObservaciones = ObservacionesMin.Visibility == Visibility.Visible ? txtMinOObservaciones.Text : null,
                        InversionLote = currentProject.InversionLotes
                    };

                    Response response = null;

                    if (Estructura == null)
                        response = DependencyRegister._EstructuraService.InsertEstructura(newEstructura);
                    else
                    {
                        newEstructura.Id = Estructura.Id;
                        response = DependencyRegister._EstructuraService.UpdateEstructura(newEstructura);
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
            if (!string.IsNullOrWhiteSpace(txtNoZona.Text) && !string.IsNullOrWhiteSpace(txtMaxOcupacion.Text) && !string.IsNullOrWhiteSpace(txtMinOcupacion.Text))
                return true;

            return false;
        }

        private void Browse_Click_Max(object sender, RoutedEventArgs e)
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
        private void Browse_Click_Min(object sender, RoutedEventArgs e)
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
    }
}
