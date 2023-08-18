using ApplicationService.Proyectos.IService;
using DIRU.Views.Common;
using DIRU.Views.InversionLotes.Evaluaciones;
using DropDownMenu.Views.InversionLotes;
using Entity.Entitys.Proyectos;
using Entity.Entitys.Proyectos.InversionesLotes;
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

namespace DIRU.Views.InversionLotes.Diagnostico
{
    /// <summary>
    /// Interaction logic for Diagnosticos.xaml
    /// </summary>
    public partial class Diagnosticos : UserControl
    {
        private  Proyecto currentProject;
        private readonly IProyectoService _proyectoService;
        public Diagnosticos(Proyecto currentProject, IProyectoService proyectoService)
        {
            InitializeComponent();
            _proyectoService = proyectoService;
            
          
            if (currentProject != null) {
                this.currentProject = currentProject;
                Title.Text = "Diagnóstico del terreno de " + currentProject.Nombre;

                if ((int)currentProject.Estado > 0) {
                    NoTerreno.Value = currentProject.InversionLotes.NoTerreno;
                    SuperficieTotal.Value = currentProject.SuperficieTotal;
                    SuperficieVerde.Value = currentProject.InversionLotes.SuperficieVerde;
                    SuperficieHidrica.Value = currentProject.InversionLotes.SuperficieHidrica;
                    ProfundidadManto.Value = currentProject.InversionLotes.ProfundidadManto;
                    TopografiaPendientes.Value = currentProject.InversionLotes.TopografiaPendiente;
                    ValoresPaisajisticos.Text = currentProject.InversionLotes.ValoresPaisajisticos;
                    CantHabitantes.Value = currentProject.InversionLotes.CantidadHabitantes;
                    txtviasTransporte.Text = currentProject.InversionLotes.ViasTransportePublico;

                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos()) { 
        
                
                InversionLote inversionLote = currentProject.InversionLotes != null? currentProject.InversionLotes : new InversionLote();
                inversionLote.NoTerreno = NoTerreno.Value.Value;
          
               // inversionLote.AreaLotes = float.TryParse(txtAreas.Text, out res1) ? res1 : 0;
                inversionLote.SuperficieVerde = SuperficieVerde.Value.Value;
                inversionLote.SuperficieHidrica = SuperficieHidrica.Value.Value;
                inversionLote.ProfundidadManto = ProfundidadManto.Value.Value;
                inversionLote.TopografiaPendiente = TopografiaPendientes.Value.Value;
                inversionLote.ValoresPaisajisticos = ValoresPaisajisticos.Text;
                inversionLote.CantidadHabitantes = CantHabitantes.Value.Value;
                inversionLote.ViasTransportePublico = txtviasTransporte.Text;

            currentProject.InversionLotes = inversionLote;
            currentProject.Estado = EstadoProyecto.Diagnosticado;
            var response = _proyectoService.UpdateProyecto(currentProject);
            if (response.Status.Equals(StatusResponse.OK))
            {

                new MessageBoxCustom("Diagnóstico guardado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();

                InversionLoteView.MainInversion.Children.Clear();
                    InversionLoteView.MainInversion.Children.Add(new EvaluacionCapacidad());
                    InversionLoteView.mEvaluaciones.IsEnabled = true;
            }
            else
                new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
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


            if (NoTerreno.Value.HasValue && SuperficieVerde.Value.HasValue && SuperficieHidrica.Value.HasValue &&
                ProfundidadManto.Value.HasValue && TopografiaPendientes.Value.HasValue && ValoresPaisajisticos.Text != null && CantHabitantes.Value.HasValue)
                return true;

            return false;
        }
    }
}
