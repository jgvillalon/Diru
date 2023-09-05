using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DIRU.Views.Nomencladores.Generales.Organismos;
using DIRU.Views.RegulacionesUrbanas.Plantas;
using DropDownMenu;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
using iTextSharp.text.pdf.codec.wmf;
using Repository.Common;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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
using Xceed.Wpf.Toolkit;

namespace DIRU.Views.RegulacionesUrbanas.DatosEntradaDiseño
{
    /// <summary>
    /// Interaction logic for LocalesToPlantaForm.xaml
    /// </summary>
    public partial class LocalesToPlantaForm : Window
    {
        private readonly IPlantaService _plantaService;
        private readonly Planta _planta;
        private decimal areaTotal = 0;
        private decimal areaLibreTotal = 0;
        
       
        private List<LocalPlanta> oldLocales = new List<LocalPlanta>();
        public LocalesToPlantaForm(Planta planta)
        {
            InitializeComponent();
            _planta = planta;
            _plantaService = DependencyRegister._plantaService;
            if (_planta != null) 
            {
                lblPlanta.Text = _planta.Descripcion;
                CantArea.Value = MainWindow.currentProject.AreaOcupada;
                CantAltura.Value = _planta.Altura;

            }
            
            oldLocales = planta.Locales != null? planta.Locales.Where(l => l.Nuevo == false).ToList() : new List<LocalPlanta>();
            dgPlanta.ItemsSource = oldLocales;

            var estados = Enum.GetValues(typeof(ElementoEstado)).Cast<ElementoEstado>().ToList();
            var acciones = Enum.GetValues(typeof(AccionLocal)).Cast<AccionLocal>().ToList();
            

            // Establecer el ItemsSource del ComboBox en la columna
            estadoColumn.ItemsSource = estados;
            accionColumn.ItemsSource = acciones;



        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
             oldLocales = dgPlanta.ItemsSource as List<LocalPlanta>;

            if (oldLocales.Sum(l => l.AreaOcupada) <= CantArea.Value.Value)
            { 
                _planta.RemoveAllLocales();

                List<LocalPlanta> newlocales = new List<LocalPlanta>();

                foreach (var local in oldLocales) {
                    newlocales.Add(new LocalPlanta { Local = local.Local, AreaOcupada = local.AreaOcupada, Nuevo = true,Estado = local.Estado, NoLocal = local.NoLocal, Accion = local.Accion });
                }
                _planta.Altura = CantAltura.Value?? 0;
                _planta.AlturaNueva = CantAltura.Value ?? 0;
                _planta.AddLocales(oldLocales);
                _planta.AddLocales(newlocales);
                _planta.Area = _planta.Locales.Where(l => !l.Nuevo).Sum(l => l.AreaOcupada);
                _planta.AreaNueva = _planta.Locales.Where(l => !l.Nuevo).Sum(l => l.AreaOcupada);
                var response = _plantaService.UpdatePlanta(_planta);
               
                if (response.Status.Equals(StatusResponse.OK))
                {
                    PlantaSearchOptions options = new PlantaSearchOptions { InversionLoteId = MainWindow.currentProject.InversionLotes.Id, Nuevo = false };

                    DatosEntradaDiseño.datagrid.ItemsSource = _plantaService.FindAllPlantas(options);
                    new MessageBoxCustom("Operación completada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                  
                }
                else
                    new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
           }
            else
                new MessageBoxCustom("No puede exceder el área total", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddLocal_Click(object sender, RoutedEventArgs e)
        {
            var locales = dgPlanta.ItemsSource as List<LocalPlanta>;
            locales.Add(new LocalPlanta());
            dgPlanta.ItemsSource = locales;
            textcolumn.IsReadOnly = false;
            dgPlanta.Items.Refresh();
            areaTotal = 0;



        }

        private void dgPlanta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocalPlanta localPlanta = dgPlanta.SelectedItem as LocalPlanta;
            if (localPlanta != null)
            {
                DeleteLocal.IsEnabled = true;
               
                if(localPlanta.Libre)
                    textcolumn.IsReadOnly = true;
                else   
                textcolumn.IsReadOnly = false;
            }
        }

        private void DeleteLocal_Click(object sender, RoutedEventArgs e)
        {
            LocalPlanta localPlanta = dgPlanta.SelectedItem as LocalPlanta;
            if (localPlanta != null) 
            {
                oldLocales.Remove(localPlanta);
                dgPlanta.Items.Refresh();

                DeleteLocal.IsEnabled= false;

            }
        }

        private void Area_Changed(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

          
            var decimalUpDown = sender as DecimalUpDown;
            var value = decimalUpDown.Value;
           
            var selected = dgPlanta.SelectedItem as LocalPlanta;

            if (value.HasValue)
            {
                decimal nuevoValor = value.Value;

                // Restar el valor anterior y sumar el nuevo valor a la variable sumaArea
                if(e.OldValue != null)
                areaTotal -= (decimal)e.OldValue;
                
                areaTotal += (decimal)nuevoValor;
                txtAreaTotal.Text = "Área Total: " + areaTotal.ToString() + " m2";
            }

           
        }

        private void AddAreaLibre_Click(object sender, RoutedEventArgs e)
        {
            var locales = dgPlanta.ItemsSource as List<LocalPlanta>;
            locales.Add(new LocalPlanta { Local = "Área Libre", Libre = true });
            dgPlanta.ItemsSource = locales;
            textcolumn.IsReadOnly= true;
            dgPlanta.Items.Refresh();
            areaTotal = 0;
        }

        private void Accion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedValue = comboBox.SelectedItem; // Obtener elemento seleccionado

            // Realizar las modificaciones necesarias en la columna2
            if (selectedValue != null)
            {
                LocalPlanta item = dgPlanta.SelectedItem as LocalPlanta; // Reemplaza "YourModel" con tu tipo de modelo

                // Sumar 2 al valor actual de la columna2 
                if (item != null) 
                {
                    var locales = dgPlanta.ItemsSource as List<LocalPlanta>;
                    locales.First(l =>l.Id == item.Id).AccionPrecio = item.AccionPrecio +2;
                    dgPlanta.ItemsSource = locales;

                   
                }// Actualizar los cambios visuales en la interfaz gráfica
            }
        }
    }
}
