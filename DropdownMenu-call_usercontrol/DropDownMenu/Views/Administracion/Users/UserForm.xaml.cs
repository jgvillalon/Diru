using ApplicationService.IServices;
using ApplicationService.Seguridad.Maps;
using DIRU.Views.Common;
using Entity.Entitys;
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
    /// Interaction logic for UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        private UserGrid _user;
        private readonly IUserService _userService;
        public UserForm(IUserService userService, UserGrid user = null)
        {
            InitializeComponent();
            _userService = userService;
            comboRol.ItemsSource = new List<string> {"Administrador", "Inversionista", "Usuario" };

            if (user != null) {
                _user = user;
                tx_username.Text = _user.Username;
                tx_apellidos.Text = _user.Apellidos;
                tx_nombre.Text = _user.Nombre;
                tx_telefono.Text = _user.Telefono;
                comboRol.Text = _user.Role;
                pass.Password = "aaaaaaaaaaaaa";
                confirmPass.Password = "aaaaaaaaaaaaa";
                pass.IsEnabled = false;
                confirmPass.IsEnabled = false;
                CheckActivo.IsEnabled = true;
                CheckActivo.IsChecked = _user.Active;
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
            Role rol;
            switch (comboRol.Text)
            {
                case "SuperAdministrador":
                    rol = Role.SuperAdministrador;
                    break;
                case "Administrador":
                    rol = Role.Administrador;
                    break;
                case "Inversionista":
                    rol = Role.Inversionista;
                    break;
                default:
                    rol = Role.Usuario;
                    break;

            }

            if (ValidateCampos())
            {
                if (ValidatePassWord()) { 

                if (_user == null)
                {
                    User newUser = new User
                    {
                        Active = true,
                        Username = tx_username.Text,
                        Nombre = tx_nombre.Text,
                        Apellidos = tx_apellidos.Text,
                        Telefono = tx_telefono.Text,
                        Password = pass.Password,
                        Correo = tx_correo.Text

                };

                    UserRole userRole = new UserRole
                    {
                        Role = rol,
                        User = newUser
                    };
                    newUser.UserRole = userRole;
                    var response = _userService.InsertUser(newUser);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Usuario creado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        LimpiarCampos();
                    }
                    else if (response.Status.Equals(StatusResponse.Exist))
                        new MessageBoxCustom("El usuario ya existe.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    var user = _userService.GetUserbyId(_user.Id);
                    user.Username = tx_username.Text;
                    user.Nombre = tx_nombre.Text;
                    user.Apellidos = tx_apellidos.Text;
                    user.Telefono = tx_telefono.Text;
                    user.Telefono = tx_telefono.Text;
                    user.UserRole.Role = rol;
                    user.Correo = tx_correo.Text;
                    user.Active = CheckActivo.IsChecked.HasValue? CheckActivo.IsChecked.Value : false;

                    var response = _userService.UpdateUser(user);
                    if (response.Status.Equals(StatusResponse.OK))
                    {

                        new MessageBoxCustom("Usuario modificado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                        gridRefresh();
                        this.Close();
                        
                    }
                    else
                        new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
                else
                    new MessageBoxCustom("LAs contraseñas no coinciden.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else
                new MessageBoxCustom("Existen campos vacíos.", MessageType.Error, MessageButtons.Ok).ShowDialog();
            
        }
        private void LimpiarCampos()
        {
            tx_username.Text = null;
            tx_apellidos.Text = null;
            tx_nombre.Text = null;
            tx_telefono.Text = null;
            pass.Password = null;
            confirmPass.Password = null;
            comboRol.Text = null;
            tx_correo.Text = null;
        }
        private void gridRefresh()
        {
            ManageUser.dataUser.SelectedItem = null;
            ManageUser.dataUser.ItemsSource = _userService.FindAllUsers();
            ManageUser.Edit.IsEnabled = false;
            ManageUser.Delete.IsEnabled = false;
        }
        private bool ValidateCampos()
        {
            

            if (!string.IsNullOrWhiteSpace(tx_username.Text) && !string.IsNullOrWhiteSpace(tx_nombre.Text)
                && !string.IsNullOrWhiteSpace(tx_apellidos.Text) && !string.IsNullOrWhiteSpace(pass.Password) && !string.IsNullOrWhiteSpace(confirmPass.Password) && !string.IsNullOrWhiteSpace(comboRol.Text))
                return true;

            return false;
        }
        private bool ValidatePassWord()
        {
            if (!pass.Password.Equals(confirmPass.Password)) {
               // confirmPass.BorderBrush = Brushes.Red;
                return false;
            }

          
            return true;
        }
        }
}
