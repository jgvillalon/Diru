using ApplicationService.Proyectos.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DropDownMenu;
using DropDownMenu.Views.InversionLotes;
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
    /// Interaction logic for CapacidadForm.xaml
    /// </summary>
    public partial class CapacidadForm : Window
    {
        Contadores counts = new Contadores { Background = Brushes.Transparent, CountA = 0, CountB = 0, CountC = 0 };
        //public SolidColorBrush backgrundEvalGeneral = Brushes.Transparent;
        public Capacidad _capacidad;
        private readonly ICapacidadService _capacidadService;
        public CapacidadForm(ICapacidadService capacidadService, Capacidad capacidad = null)
        {
            InitializeComponent();
            this.DataContext = counts;
            _capacidadService = capacidadService;
            if (capacidad != null)
            {
                //txtCodigoCapacidad.Text = capacidad.Codigo;
                _capacidad = capacidad;
                         comboAreaUrbanizada.Text = capacidad.AreaUrbanizada;
                         comboContaminacionAcuifera.Text = capacidad.ContAcuifera;
                         comboContaminacionSonora.Text = capacidad.ContSonora;
                         comboDeslizamiento.Text = capacidad.Desplazamiento;
                         comboEvaluacionAcuifera.Text = capacidad.EvalContAcuifera;
                         comboEvaluacionContaminacionSonora.Text = capacidad.EvalContSonora;
                         comboEvaluacionIncendio.Text = capacidad.EvalIncendios;
                         comboEvaluacionInundaciones.Text = capacidad.EvalInundaciones;
                         comboEvaluacionUrbanizacion.Text = capacidad.EvalUrbanizacion;
                         comboEvaluacionDeslizamiento.Text = capacidad.EvalDeslizamiento;
                         comboIncendios.Text = capacidad.Incendios;
                         comboInundaciones.Text = capacidad.Inundaciones;
                         comboUsoIndustrial.Text = capacidad.UsoIndustrial;
                         comboUsoResindecia.Text = capacidad.UsoResidencial;
                         EG.Text = capacidad.EvalGeneral;




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
                if (_capacidad == null)
                {
                    Capacidad newCapacidad = new Capacidad
                    {
                        AreaUrbanizada = comboAreaUrbanizada.Text,
                        ContAcuifera = comboContaminacionAcuifera.Text,
                        ContSonora = comboContaminacionSonora.Text,
                        Desplazamiento = comboDeslizamiento.Text,
                        EvalContAcuifera = comboEvaluacionAcuifera.Text,
                        EvalContSonora = comboEvaluacionContaminacionSonora.Text,
                        EvalIncendios = comboEvaluacionIncendio.Text,
                        EvalInundaciones = comboEvaluacionInundaciones.Text,
                        EvalDeslizamiento = comboEvaluacionDeslizamiento.Text,
                        EvalUrbanizacion = comboEvaluacionUrbanizacion.Text,
                        Incendios = comboIncendios.Text,
                        Inundaciones = comboInundaciones.Text,
                        UsoIndustrial = comboUsoIndustrial.Text,
                        UsoResidencial = comboUsoResindecia.Text,
                        EvalGeneral = EG.Text,
                        Zona = EvaluacionCapacidad.zonaCount,
                        Proyecto = MainWindow.currentProject
                        
                      
                    };

                    var response = _capacidadService.InsertCapacidad(newCapacidad);
                    if (response.Status.Equals(StatusResponse.OK))
                    {
                        EvaluacionCapacidad.zonaCount++;
                        InversionLoteView.mVulnerabilidad.IsEnabled = true;
                        if ((int)MainWindow.currentProject.Estado <= 3) {
                            MainWindow.currentProject.Estado = EstadoProyecto.EvaluandoVulnerabilidad;
                            DependencyRegister._proyectoService.UpdateProyecto(MainWindow.currentProject);
                        }
                        new MessageBoxCustom("Zona evaluada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La zona ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var capacidad = _capacidadService.GetCapacidadbyId(_capacidad.Id);

                    capacidad.AreaUrbanizada = comboAreaUrbanizada.Text;
                        capacidad.ContAcuifera = comboContaminacionAcuifera.Text;
                        capacidad.ContSonora = comboContaminacionSonora.Text;
                        capacidad.Desplazamiento = comboDeslizamiento.Text;
                        capacidad.EvalContAcuifera = comboEvaluacionAcuifera.Text;
                        capacidad.EvalContSonora = comboEvaluacionContaminacionSonora.Text;
                        capacidad.EvalIncendios = comboEvaluacionIncendio.Text;
                        capacidad.EvalInundaciones = comboEvaluacionInundaciones.Text;
                        capacidad.EvalUrbanizacion = comboEvaluacionUrbanizacion.Text;
                        capacidad.EvalDeslizamiento = comboEvaluacionDeslizamiento.Text;
                        capacidad.Incendios = comboIncendios.Text;
                        capacidad.Inundaciones = comboInundaciones.Text;
                        capacidad.UsoIndustrial = comboUsoIndustrial.Text;
                        capacidad.UsoResidencial = comboUsoResindecia.Text;
                        capacidad.EvalGeneral = EG.Text;
                      


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
            }
            else
                new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void gridRefresh()
        {
            EvaluacionCapacidad.datagrid.SelectedItem = null;
            CapacidadSearchOptions options = new CapacidadSearchOptions { ProyectoId = MainWindow.currentProject.Id };
            EvaluacionCapacidad.datagrid.ItemsSource = _capacidadService.FindAllCapacidads(options);
            EvaluacionCapacidad.Edit.IsEnabled = false;
            EvaluacionCapacidad.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
             comboAreaUrbanizada.SelectedItem = null;
            comboAreaUrbanizada.Background = Brushes.Transparent;
            comboContaminacionAcuifera.SelectedItem = null;
            comboContaminacionAcuifera.Background = Brushes.Transparent;
            comboContaminacionSonora.SelectedItem = null;
            comboContaminacionSonora.Background = Brushes.Transparent;
            comboDeslizamiento.SelectedItem = null;
            comboDeslizamiento.Background = Brushes.Transparent;
            comboEvaluacionAcuifera.SelectedItem = null;
            comboEvaluacionAcuifera.Background = Brushes.Transparent;
            comboEvaluacionContaminacionSonora.SelectedItem = null;
            comboEvaluacionContaminacionSonora.Background = Brushes.Transparent;
            comboEvaluacionIncendio.SelectedItem = null;
            comboEvaluacionIncendio.Background = Brushes.Transparent;
            comboEvaluacionInundaciones.SelectedItem = null;
            comboEvaluacionInundaciones.Background = Brushes.Transparent;
            comboEvaluacionUrbanizacion.SelectedItem = null;
            comboEvaluacionUrbanizacion.Background = Brushes.Transparent;
            comboEvaluacionDeslizamiento.SelectedItem = null;
            comboEvaluacionDeslizamiento.Background = Brushes.Transparent;
            comboIncendios.SelectedItem = null;
            comboIncendios.Background = Brushes.Transparent;
            comboInundaciones.SelectedItem = null;
            comboInundaciones.Background = Brushes.Transparent;
            comboUsoIndustrial.SelectedItem = null;
            comboUsoIndustrial.Background = Brushes.Transparent;
            comboUsoResindecia.SelectedItem = null;
            comboUsoResindecia.Background = Brushes.Transparent;
            
            EG.SelectedItem = null;
            EG.Background = Brushes.Transparent;
            EGBorder.Background = Brushes.Transparent;
            CA.Text = "0";
            CB.Text = "0";
            CC.Text = "0";

        }
        private bool ValidateCampos()
        {


            if (comboAreaUrbanizada.SelectedItem != null && comboContaminacionAcuifera.SelectedItem != null && comboContaminacionSonora.SelectedItem != null 
                && comboDeslizamiento.SelectedItem != null && comboEvaluacionAcuifera.SelectedItem != null && comboEvaluacionContaminacionSonora.SelectedItem != null
                && comboEvaluacionDeslizamiento != null && comboEvaluacionIncendio.SelectedItem != null && comboEvaluacionInundaciones.SelectedItem != null
                && comboEvaluacionUrbanizacion.SelectedItem != null && comboIncendios.SelectedItem != null && comboInundaciones.SelectedItem != null
                && comboUsoIndustrial.SelectedItem != null && comboUsoResindecia.SelectedItem != null && EG.SelectedItem != null)
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

        private void ComboEvaluacionUrbanizacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionUrbanizacion.SelectedItem != null)
                comboEvaluacionUrbanizacion.Background = ((ListBoxItem)(comboEvaluacionUrbanizacion.SelectedItem)).Background;
           searchInCombos("A");
           searchInCombos("B");
           searchInCombos("C");
            PictureEvalGeneral();

        }

        private void ComboEvaluacionContaminacionSonora_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionContaminacionSonora.SelectedItem != null)
                comboEvaluacionContaminacionSonora.Background = ((ListBoxItem)(comboEvaluacionContaminacionSonora.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();
        }

        private void ComboEvaluacionDeslizamiento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionDeslizamiento.SelectedItem != null)
                comboEvaluacionDeslizamiento.Background = ((ListBoxItem)(comboEvaluacionDeslizamiento.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();
        }

        private void ComboEvaluacionInundaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionInundaciones.SelectedItem != null)
                comboEvaluacionInundaciones.Background = ((ListBoxItem)(comboEvaluacionInundaciones.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();
        }

        private void ComboEvaluacionIncendio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionIncendio.SelectedItem != null)
                comboEvaluacionIncendio.Background = ((ListBoxItem)(comboEvaluacionIncendio.SelectedItem)).Background;
            searchInCombos("A");
            searchInCombos("B");
            searchInCombos("C");
            PictureEvalGeneral();
        }

        private void ComboEvaluacionAcuifera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEvaluacionAcuifera.SelectedItem != null)
            comboEvaluacionAcuifera.Background = ((ListBoxItem)(comboEvaluacionAcuifera.SelectedItem)).Background;
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

        public void searchInCombos(string eval) {
          int  count = 0;
            if (((ListBoxItem)(comboEvaluacionUrbanizacion.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionUrbanizacion.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionContaminacionSonora.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionContaminacionSonora.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionDeslizamiento.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionDeslizamiento.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionInundaciones.SelectedItem))!= null && ((ListBoxItem)(comboEvaluacionInundaciones.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionIncendio.SelectedItem))!= null && ((ListBoxItem)(comboEvaluacionIncendio.SelectedItem)).Content.ToString().Equals(eval))
                count++;
            if (((ListBoxItem)(comboEvaluacionAcuifera.SelectedItem)) != null && ((ListBoxItem)(comboEvaluacionAcuifera.SelectedItem)).Content.ToString().Equals(eval))
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
    public class Contadores
    {

        public int CountA { get; set; }
        public int CountB { get; set; }
        public int CountC { get; set; }
        public SolidColorBrush Background { get; set; }


    }
}
