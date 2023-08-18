using ApplicationService.Nomencladores.Otros.IService;
using DIRU.Views.Common;
using Entity.Entitys.Nomencladores.Otros;
using Repository.Common;
using System.Windows;

namespace DIRU.Views.Nomencladores.Otros.EstadosTecnico
{
    /// <summary>
    /// Interaction logic for EstadoTecnicoForm.xaml
    /// </summary>
    public partial class EstadoTecnicoForm : Window
    {
        public EstadoTecnico _estadoTecnico;
        private readonly IEstadoTecnicoService _estadoTecnicoService;
        public EstadoTecnicoForm(IEstadoTecnicoService estadoTecnicoService, EstadoTecnico estadoTecnico = null)
        {
            InitializeComponent();
            _estadoTecnicoService = estadoTecnicoService;
          //  ProvinciaSearchOptions provOptions = new ProvinciaSearchOptions { Active = true };
          

            if (estadoTecnico != null)
            {
               
                txtElementos.Text = estadoTecnico.Elementos;
                MinBueno.Value = estadoTecnico.MinBueno;
                MaxBueno.Value = estadoTecnico.MaxBueno;
                MinRegular.Value = estadoTecnico.MinRegular;
                MaxRegular.Value = estadoTecnico.MaxRegular;
                MinMalo.Value = estadoTecnico.MinMalo;
                MaxMalo.Value = estadoTecnico.MaxMalo;
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = estadoTecnico.Active;
                _estadoTecnico = estadoTecnico;

            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCampos())
            {
                if (_estadoTecnico == null)
                {
                    EstadoTecnico newEstadoTecnico = new EstadoTecnico
                    {
                        Active = true,
                        Elementos = txtElementos.Text,
                        MinBueno = MinBueno.Value.Value,
                        MaxBueno = MaxBueno.Value.Value,
                        MinRegular = MinRegular.Value.Value,
                        MaxRegular = MaxRegular.Value.Value,
                        MinMalo = MinMalo.Value.Value,
                        MaxMalo = MaxMalo.Value.Value

                    };

                    var response = _estadoTecnicoService.InsertEstadoTecnico(newEstadoTecnico);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("EstadoTecnico creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La estadoTecnico ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var estadoTecnico = _estadoTecnicoService.GetEstadoTecnicobyId(_estadoTecnico.Id);
                    estadoTecnico.Elementos = txtElementos.Text;
                    estadoTecnico.MinBueno = MinBueno.Value.Value;
                    estadoTecnico.MaxBueno = MaxBueno.Value.Value;
                    estadoTecnico.MinRegular = MinRegular.Value.Value;
                    estadoTecnico.MaxRegular = MaxRegular.Value.Value;
                    estadoTecnico.MinMalo = MinMalo.Value.Value;
                    estadoTecnico.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false;

                    var response = _estadoTecnicoService.UpdateEstadoTecnico(estadoTecnico);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("EstadoTecnico modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomEstadoTecnica.datagrid.SelectedItem = null;
            NomEstadoTecnica.datagrid.ItemsSource = _estadoTecnicoService.FindAllEstadoTecnicos();
            NomEstadoTecnica.Edit.IsEnabled = false;
            NomEstadoTecnica.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
            txtElementos.Text = null;
            MinMalo.Value= 1;
            MaxMalo.Value= 1;
            MinBueno.Value= 1;
            MaxBueno.Value= 1;
            MinRegular.Value= 1;
            MaxRegular.Value= 1;

        }
        private bool ValidateCampos()
        {


            if (!string.IsNullOrWhiteSpace(txtElementos.Text) && MinBueno.Value.HasValue && MaxBueno.Value.HasValue
                && MinRegular.Value.HasValue && MaxRegular.Value.HasValue && MinMalo.Value.HasValue && MaxMalo.Value.HasValue)
                return true;

            return false;
        }
    

    private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
