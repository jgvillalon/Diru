using ApplicationService.IServices;
using ApplicationService.Seguridad.Maps;
using DIRU.Views.Common;
using DropDownMenu;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIRU.Views.Administracion.Users
{
    /// <summary>
    /// Interaction logic for ManageUser.xaml
    /// </summary>
    public partial class ManageUser : UserControl
    {
        private readonly IUserService _userService;
        public static DataGrid dataUser;
        public static Button Edit;
        public static Button Delete;
        public ManageUser(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            dgUser.ItemsSource = _userService.FindAllUsers();
            dataUser = dgUser;
            if (MainWindow.currentUser.UserRole.Role != Role.SuperAdministrador)
                dataUser.Columns[6].Visibility = Visibility.Collapsed;
            Edit = EditUser;
            Delete = DeleteUser;
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            UserForm page = new UserForm(_userService);
            page.ShowDialog();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            UserGrid usergrid = dgUser.SelectedItem as UserGrid;
            
            UserForm page = new UserForm(_userService, usergrid);
            page.ShowDialog();
        }
        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EditUser.IsEnabled = true;
            DeleteUser.IsEnabled = true;

        }
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtSearch != null)
                txtSearch.Text = string.Empty;
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa eliminar el usuario?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value) { 

                UserGrid user = dgUser.SelectedItem as UserGrid;
            if (user != null)
            {
                var response = _userService.DeleteUser(user.Id);
                if (response.Status.Equals(StatusResponse.OK))
                {
                    new MessageBoxCustom("Usuario eliminado satisfactoriamente.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                   gridRefresh();

                }
                else if (response.Status.Equals(StatusResponse.InUse))
                    new MessageBoxCustom("Usuario se encuentra en uso.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                else if (response.Status.Equals(StatusResponse.NotFound))
                    new MessageBoxCustom("Usuario no encontrado.", MessageType.Error, MessageButtons.Ok).ShowDialog();
                else
                    new MessageBoxCustom("Ha ocurrido un error.", MessageType.Error, MessageButtons.Ok).ShowDialog();

            }
            }
        }
        
        private void gridRefresh()
        {
            dataUser.SelectedItem = null;
            dataUser.ItemsSource = _userService.FindAllUsers();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
        }

        private void BtnChangePass_Click(object sender, RoutedEventArgs e)
        {
            var user = dataUser.SelectedItem as UserGrid;
            ChangePassForm chpass = new ChangePassForm(_userService, user.Id);
            chpass.ShowDialog();
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            switch (comboFilter.Text)
            {
                case "Rol":
                    dgUser.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((UserGrid)f).Role.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgUser.Items.Refresh();
                    break;
                case "Nombre":
                    dgUser.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((UserGrid)f).Nombre.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgUser.Items.Refresh();
                    break;
                case "Apellidos":
                    dgUser.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
   ((UserGrid)f).Apellidos.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgUser.Items.Refresh();
                    break;
                default:
                    dgUser.Items.Filter = f => string.IsNullOrEmpty(txtSearch.Text) ? true : (
    ((UserGrid)f).Username.ToLower().Contains(txtSearch.Text.ToLower()));
                    dgUser.Items.Refresh();
                    break;

            }

          
        }
    }
}
