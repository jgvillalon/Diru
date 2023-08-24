using DIRU.Views.Common;
using DIRU.Views.RegulacionesUrbanas.Alturas;
using DIRU.Views.RegulacionesUrbanas.Edificacion;
using DIRU.Views.RegulacionesUrbanas.Estructura;
using DropDownMenu;
using Entity.Entitys.Proyectos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DIRU.Views.RegulacionesUrbanas
{
    /// <summary>
    /// Interaction logic for RegulacionUrbana.xaml
    /// </summary>
    public partial class RegulacionUrbana : UserControl
    {
        public static MenuItem mEstructura;
        public static MenuItem mAltura;
        public static MenuItem mEdificacion;
        public static MenuItem mFachada;
        public static MenuItem mFunciones;
        public static MenuItem mAreas;
        public static MenuItem mPlantas;
        public static MenuItem mInfoAptitudPrimaria;

        public static MenuItem mProject;

        public static Grid MainRegulacion;
        public static Proyecto currentProject;
        public RegulacionUrbana()
        {
            InitializeComponent();
            mProject = menuProject;

            MainRegulacion = Main;
            currentProject = null;
        }
        private void DatosGenerales_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new DatosGenerales());
        }
        private void DatosCliente_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new DatosCliente());
        }
        private void AptitudesPrimarias_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MainWindow.currentProject.InversionLotes.UrlEvaluaciones))
                Process.Start(MainWindow.currentProject.InversionLotes.UrlEvaluaciones);
        }

        private void Estructura_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new EstructuraManzana());
        }

        private void Altura_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new Altura());
        }

        private void Disposicion_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new Disposicion());
        }

        private void Alineacion_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            Main.Children.Add(new Alineacion());
        }

        private void Fachada_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Funciones_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Areas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Plantas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Comercio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
