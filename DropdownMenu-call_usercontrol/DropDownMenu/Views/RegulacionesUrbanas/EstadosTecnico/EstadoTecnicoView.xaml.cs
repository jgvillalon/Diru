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
using Xceed.Wpf.Toolkit;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos;
using ApplicationService.Proyectos.IService;
using DropDownMenu;
using DropDownMenu.Views.InversionLotes;
using DIRU.Views.Common;

namespace DIRU.Views.RegulacionesUrbanas.EstadosTecnico
{
    /// <summary>
    /// Interaction logic for EstadoTecnicoView.xaml
    /// </summary>
    public partial class EstadoTecnicoView : UserControl
    {
        private Proyecto currentProject1;
        private readonly IProyectoService _proyectoService;
        public EstadoTecnicoView(Proyecto currentProject, IProyectoService proyectoService)
        {
            InitializeComponent();
            currentProject1 = currentProject;
            _proyectoService = proyectoService;
            listBoxEstadosTecnico.ItemsSource = DependencyRegister._estadoTecnicoService.FindAllEstadoTecnicos();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Crear una lista para almacenar los valores ingresados
            List<int> valoresIngresados = new List<int>();

            // Recorrer todos los elementos del ListBox
            foreach (var item in listBoxEstadosTecnico.Items)
            {
                var EstadoTecnico = (EstadoTecnico)item;
                int id = EstadoTecnico.Id;
                //var proyecto = DependencyRegister.
                // Obtener el contenedor visual (ListBoxItem) para acceder al contenido real del DataTemplate
                var listBoxItem = listBoxEstadosTecnico.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;

                // Buscar el StackPanel dentro del contenido visual usando su nombre o tipo si está nombrado en XAML
                var stackPanel = FindVisualChild<StackPanel>(listBoxItem);

                // Recorrer todos los TextBox dentro del StackPanel y obtener sus valores
                foreach (var textBox in stackPanel.Children)
                {
                    if (textBox.GetType() == typeof(IntegerUpDown))
                    {
                        var integerupdown = textBox as IntegerUpDown;

                        EstadoTecnicoProyecto EstadoTecnicoProyecto = new EstadoTecnicoProyecto
                        {
                            Proyecto = currentProject1,
                            EstadoTecnico = EstadoTecnico,
                            Clasificacion = EstadoTecnico.Rango(integerupdown.Value.Value),
                            Valor = integerupdown.Value.Value
                        };


                        currentProject1.EstadoTecnicoElementos.Add(EstadoTecnicoProyecto);
                        _proyectoService.UpdateProyecto(currentProject1);
                        new MessageBoxCustom("Datos modificados satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    }
                }
            }
        }

        // Ahora la lista "valoresIngresados" contiene todos los valores ingresados por el usuario en los TextBox del ListBox

        // Función auxiliar para encontrar un elemento visual con un determinado tipo utilizando recursividad 
        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    var foundChild = FindVisualChild<T>(child);
                    if (foundChild != null)
                        return foundChild;
                }
            }
            return null;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.MainView.Children.OfType<InversionLoteView>().Count() > 0)
                InversionLoteView.MainInversion.Children.Clear();
        }


    }
}
