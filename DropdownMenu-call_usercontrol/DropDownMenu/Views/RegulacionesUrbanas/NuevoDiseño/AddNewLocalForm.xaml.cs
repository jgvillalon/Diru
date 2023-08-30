using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Dependencies;
using DIRU.Views.Common;
using DropDownMenu;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Common;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using Xceed.Wpf.Toolkit;

namespace DIRU.Views.RegulacionesUrbanas.NuevoDiseño
{
    /// <summary>
    /// Interaction logic for AddNewLocalForm.xaml
    /// </summary>
    public partial class AddNewLocalForm : Window
    {
        private readonly IPlantaService _plantaService;
        private readonly Planta _planta;
        private decimal areaTotal = 0;


        private List<LocalPlanta> newlocale = new List<LocalPlanta>();
        public AddNewLocalForm(Planta planta)
        {
            InitializeComponent();
            _planta = planta;
            _plantaService = DependencyRegister._plantaService;
            if (_planta != null)
            {
                lblPlanta.Text = _planta.Descripcion;
                CantArea.Value = MainWindow.currentProject.AreaOcupada;

            }
            newlocale = planta.Locales.Where(l => l.Nuevo == true).ToList();
            dgPlanta.ItemsSource = newlocale;

           // var acciones = Enum.GetValues(typeof(AccionLocal)).Cast<AccionLocal>().ToList();
          //  accionColumn.ItemsSource = acciones;

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            newlocale = dgPlanta.ItemsSource as List<LocalPlanta>;

            if (newlocale.Sum(l => l.AreaOcupada) <= CantArea.Value.Value)
            {
                foreach (var local in newlocale.Where(l => !l.Nuevo)) { 
                local.Nuevo = true;
                }
                
                _planta.RemoveLocales(_planta.Locales.Where(l => l.Nuevo == true).ToList());
                _planta.AddLocales(newlocale);
                _planta.AreaNueva = _planta.Locales.Where(l => l.Nuevo).Sum(l => l.AreaOcupada);
                var response = _plantaService.UpdatePlanta(_planta);

                if (response.Status.Equals(StatusResponse.OK))
                {
                    PlantaSearchOptions options = new PlantaSearchOptions { InversionLoteId = MainWindow.currentProject.InversionLotes.Id};

                    NuevosDatosEntrada.datagrid.ItemsSource = _plantaService.FindAllPlantas(options);
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




        }

        private void dgPlanta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocalPlanta localPlanta = dgPlanta.SelectedItem as LocalPlanta;
            if (localPlanta != null)
            {
                DeleteLocal.IsEnabled = true;
            }
        }

        private void DeleteLocal_Click(object sender, RoutedEventArgs e)
        {
            LocalPlanta localPlanta = dgPlanta.SelectedItem as LocalPlanta;
            if (localPlanta != null)
            {
                newlocale.Remove(localPlanta);
                dgPlanta.Items.Refresh();

                DeleteLocal.IsEnabled = false;

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
                if (e.OldValue != null)
                    areaTotal -= (decimal)e.OldValue;
                if (areaTotal + nuevoValor <= CantArea.Value) 
                {
                    areaTotal += nuevoValor;
                    txtAreaTotal.Text = "Área Total: " + areaTotal.ToString() + " m2";
                }
                else
                {
                  
                    decimalUpDown.Value = (decimal)e.OldValue;
                    new MessageBoxCustom("No puede exceder el área total", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }

            }


        }
    }

    
}