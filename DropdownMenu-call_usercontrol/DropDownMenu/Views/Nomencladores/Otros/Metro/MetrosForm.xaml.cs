using DIRU.Views.Common;
using Entity.Entitys.Nomencladores.Otros;
using ApplicationService.Nomencladores.Otros.IService;
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
using System.Windows.Shapes;

namespace DIRU.Views.Nomencladores.Otros.Metro
{
    /// <summary>
    /// Interaction logic for MetrosForm.xaml
    /// </summary>
    public partial class MetrosForm : Window
    {
        public Metros _metros;
        private readonly IMetrosService _metrosService;
        public MetrosForm(IMetrosService metrosService, Metros metros = null)
        {
            InitializeComponent();
            _metrosService = metrosService;

            if (metros != null)
            {
                //txtCodigoMetros.Text = metros.Codigo;
                txtNombreMetros.Text = metros.Cantidad.ToString();
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = metros.Active;
                _metros = metros;


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
                if (_metros == null)
                {
                    Metros newMetros = new Metros
                    {
                        Active = true,
                        // Codigo = txtCodigoMetros.Text,
                        Cantidad = float.Parse(txtNombreMetros.Text)


                    };

                    var response = _metrosService.InsertMetros(newMetros);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Metros creada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("La metros ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var metros = _metrosService.GetMetrosbyId(_metros.Id);
                    // metros.Codigo = txtCodigoMetros.Text;
                    metros.Cantidad = int.Parse(txtNombreMetros.Text);
                    metros.Active = CheckActivo.IsChecked.HasValue ? CheckActivo.IsChecked.Value : false;


                    var response = _metrosService.UpdateMetros(metros);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Metros modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
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
            NomMetros.datagrid.SelectedItem = null;
            NomMetros.datagrid.ItemsSource = _metrosService.FindAllMetros();
            NomMetros.Edit.IsEnabled = false;
            NomMetros.Delete.IsEnabled = false;
        }
        private void LimpiarCampos()
        {
            // txtCodigoMetros.Text = null;
            txtNombreMetros.Text = null;

        }
        private bool ValidateCampos()
        {


            if (!string.IsNullOrWhiteSpace(txtNombreMetros.Text))
                return true;

            return false;
        }
    }

}

