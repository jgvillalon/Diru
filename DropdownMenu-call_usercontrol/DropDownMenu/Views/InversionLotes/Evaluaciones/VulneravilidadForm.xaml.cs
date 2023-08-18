using ApplicationService.Proyectos.IService;
using DIRU.Views.Common;
using DropDownMenu;
using Entity.Entitys.Proyectos;
using Repository.Common;
using Repository.Proyectos.Options;
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

namespace DIRU.Views.InversionLotes.Evaluaciones
{
    /// <summary>
    /// Interaction logic for VulneravilidadForm.xaml
    /// </summary>
    public partial class VulneravilidadForm : Window
    {
        Contadores counts = new Contadores { Background = Brushes.Transparent, CountA = 0, CountB = 0, CountC = 0 };
        //public SolidColorBrush backgrundEvalGeneral = Brushes.Transparent;
        public Capacidad _capacidad;
        private readonly ICapacidadService _capacidadService;
        public VulneravilidadForm(ICapacidadService capacidadService, Capacidad capacidad)
        {
            InitializeComponent();
            this.DataContext = counts;
            _capacidadService = capacidadService;
            if (capacidad != null)
            {
                //txtCodigoCapacidad.Text = capacidad.Codigo;
                _capacidad = capacidad;
                comboEcoConservado.Text = capacidad.EcoConservado;
                comboEcoDañado.Text = capacidad.EcoDannado;
                comboEvaluacionEcosistema.Text = capacidad.EvaluacionEcosistema;
                comboEvaluacionSuelos.Text = capacidad.EvaluacionSuelos;
                comboEvaluacionVaguadas.Text = capacidad.EvaluacionVaguada;
                comboEvaluacionVegetacion.Text = capacidad.EvaluacionVegetacion;
                comboEvaluacionVisuales.Text = capacidad.EvaluacionVisuales;
                comboPalmar.Text = capacidad.Palmar;
                comboPocaVegetacion.Text = capacidad.PocaVegetacion;
                comboSueloArido.Text = capacidad.SueloArido;
                comboSueloCenagoso.Text = capacidad.SueloCenagoso;
                comboSueloFertil.Text = capacidad.SueloFertil;
                comboVaguadas.Text = capacidad.VaguadaNatural;
                comboVegetacionCultivo.Text = capacidad.VegetacionCultivo;
                comboVisuales.Text = capacidad.Visuales;
              
                EG.Text = capacidad.EvalGeneralVulnerabilidad;




            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
              
                
                    var capacidad = _capacidadService.GetCapacidadbyId(_capacidad.Id);

                    capacidad.SueloFertil = comboSueloFertil.Text;
                    capacidad.SueloArido = comboSueloArido.Text;
                    capacidad.SueloCenagoso = comboSueloCenagoso.Text;
                    capacidad.EvaluacionSuelos = comboEvaluacionSuelos.Text;
                    capacidad.Visuales = comboVisuales.Text;
                    capacidad.EvaluacionVisuales = comboEvaluacionVisuales.Text;
                    capacidad.VegetacionCultivo = comboVegetacionCultivo.Text;
                    capacidad.PocaVegetacion = comboPocaVegetacion.Text;
                    capacidad.Palmar = comboPalmar.Text;
                    capacidad.EvaluacionVegetacion = comboEvaluacionVegetacion.Text;
                    capacidad.EcoDannado = comboEcoDañado.Text;
                    capacidad.EcoConservado = comboEcoConservado.Text;
                    capacidad.EvaluacionEcosistema = comboEvaluacionEcosistema.Text;
                    capacidad.VaguadaNatural = comboVaguadas.Text;
                    capacidad.EvaluacionVaguada = comboEvaluacionVaguadas.Text;
                    capacidad.EvalGeneralVulnerabilidad = EG.Text;



                    var response = _capacidadService.UpdateCapacidad(capacidad);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Capacidad modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        this.Close();

                    }
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                
            }
            else
                new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void gridRefresh()
        {
            EvaluacionVulnerabilidad.datagrid.SelectedItem = null;
            CapacidadSearchOptions options = new CapacidadSearchOptions { ProyectoId = MainWindow.currentProject.Id };
            EvaluacionVulnerabilidad.datagrid.ItemsSource = _capacidadService.FindAllCapacidads(options);
            EvaluacionVulnerabilidad.Edit.IsEnabled = false;
           
        }
        private void LimpiarCampos()
        {
            comboSueloArido.SelectedItem = null;
            comboSueloCenagoso.SelectedItem = null;
            comboSueloFertil.SelectedItem = null;
            comboEvaluacionSuelos.SelectedItem = null;
            comboEvaluacionSuelos.Background = Brushes.Transparent;
            comboVisuales.SelectedItem = null;
            comboEvaluacionVisuales.SelectedItem = null;
            comboEvaluacionVisuales.Background = Brushes.Transparent;
            comboVegetacionCultivo.SelectedItem = null;
            comboPocaVegetacion.SelectedItem = null;
            comboPalmar.SelectedItem = null;
            comboEvaluacionVegetacion.SelectedItem = null;
            comboEvaluacionVegetacion.Background = Brushes.Transparent;
            comboEcoConservado.SelectedItem = null;
            comboEcoDañado.SelectedItem = null;
            comboEvaluacionEcosistema.SelectedItem = null;
            comboEvaluacionEcosistema.Background = Brushes.Transparent;
            comboVaguadas.SelectedItem = null;
            comboEvaluacionVaguadas.SelectedItem = null;
            comboEvaluacionVaguadas.Background = Brushes.Transparent;

            EG.SelectedItem = null;
            EG.Background = Brushes.Transparent;
            EGBorder.Background = Brushes.Transparent;
            CA.Text = "0";
            CB.Text = "0";
            CC.Text = "0";

        }
        private bool ValidateCampos()
        {


            if (comboSueloArido.SelectedItem != null && comboSueloCenagoso.SelectedItem != null && comboSueloFertil.SelectedItem != null
                && comboEvaluacionSuelos.SelectedItem != null && comboVisuales.SelectedItem != null && comboEvaluacionVisuales.SelectedItem != null
                && comboVegetacionCultivo != null && comboPocaVegetacion.SelectedItem != null && comboPalmar.SelectedItem != null
                && comboEvaluacionVegetacion.SelectedItem != null && comboEcoConservado.SelectedItem != null && comboEcoDañado.SelectedItem != null
                && comboEvaluacionEcosistema.SelectedItem != null && comboVaguadas.SelectedItem != null && comboEvaluacionVaguadas.SelectedItem != null && EG.SelectedItem != null)
                return true;

            return false;
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

        private void ComboEvaluacionSuelos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionSuelos.SelectedItem != null)
                comboEvaluacionSuelos.Background = ((ListBoxItem)(comboEvaluacionSuelos.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();

        }

        private void ComboEvaluacionVisuales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboEvaluacionVisuales.SelectedItem != null)
            comboEvaluacionVisuales.Background = ((ListBoxItem)(comboEvaluacionVisuales.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();
        }

        private void ComboEvaluacionVegetacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionVegetacion.SelectedItem != null)
                comboEvaluacionVegetacion.Background = ((ListBoxItem)(comboEvaluacionVegetacion.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();

        }

        private void ComboEvaluacionEcosistema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionEcosistema.SelectedItem != null)
                comboEvaluacionEcosistema.Background = ((ListBoxItem)(comboEvaluacionEcosistema.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();

        }

        private void ComboEvaluacionVaguadas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionVaguadas.SelectedItem != null)
                comboEvaluacionVaguadas.Background = ((ListBoxItem)(comboEvaluacionVaguadas.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();

        }
        public void PictureEvalGeneral()
        {
            CA.Text = counts.CountA.ToString();
            CB.Text = counts.CountB.ToString();
            CC.Text = counts.CountC.ToString();
            if (counts.CountA > counts.CountB && counts.CountA > counts.CountC)
            {
                counts.Background = Brushes.Green;
                EG.Text = "A";
            }
            else if (counts.CountB > counts.CountA && counts.CountB > counts.CountC)
            {
                counts.Background = Brushes.Yellow;
                EG.Text = "B";
            }
            else if (counts.CountC > counts.CountA && counts.CountC > counts.CountB)
            {
                counts.Background = Brushes.Red;
                EG.Text = "C";
            }
            EGBorder.Background = counts.Background;

        }

        public void searchInCombos(string eval)
        {
            int count = 0;
            if (((ListBoxItem)(comboEvaluacionEcosistema.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionEcosistema.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionSuelos.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionSuelos.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionVaguadas.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionVaguadas.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionVegetacion.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionVegetacion.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionVisuales.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionVisuales.SelectedItem)).Content.ToString().Equals(eval))
                count++;
          
            if (eval.Equals("A"))
                counts.CountA = count;
            else if (eval.Equals("B"))
                counts.CountB = count;
            else
                counts.CountC = count;

        }

        private void ComboEG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EG.SelectedItem != null) { 
                EG.Background = ((ListBoxItem)(EG.SelectedItem)).Background;
            EGBorder.Background = EG.Background;
            }
        }
    }
}
