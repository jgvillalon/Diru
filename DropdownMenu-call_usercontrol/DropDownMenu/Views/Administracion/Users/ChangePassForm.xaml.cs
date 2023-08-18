using ApplicationService.IServices;
using ApplicationService.Seguridad.Maps;
using DIRU.Views.Common;
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

namespace DIRU.Views.Administracion.Users
{
    /// <summary>
    /// Interaction logic for ChangePassForm.xaml
    /// </summary>
    public partial class ChangePassForm : Window
    {
        private readonly IUserService _userService;
        private readonly int _userId;
        public ChangePassForm(IUserService userService,int userID)
        {
            InitializeComponent();
            _userService = userService;
            _userId = userID;
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
            if (string.IsNullOrEmpty(txtnewPass.Password) || string.IsNullOrEmpty(txtconfirmNewPass.Password))
                new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            else if (!txtnewPass.Password.Equals(txtconfirmNewPass.Password))
                new MessageBoxCustom("Las contraseñas no coinciden.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            else { 
          
            var response = _userService.ChangePassword(_userId, txtnewPass.Password);
                if (response.Status.Equals(StatusResponse.OK))
                {
                    new MessageBoxCustom("Contraseña modificada satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    this.Close();

                }
                else
                    new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            
        }
        }

    }
}
