using DIRU.Dependencies;
using DIRU.Views.Administracion.Users;
using DropDownMenu;
using Entity.Entitys;
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

namespace DIRU.Views.Common
{
    /// <summary>
    /// Interaction logic for MyUserAcount.xaml
    /// </summary>
    public partial class MyUserAcount : Window
    {
        public User currentUser;
        public MyUserAcount()
        {
            InitializeComponent();
            currentUser = MainWindow.currentUser;
            Username.Content = currentUser.Username;
            Fullname.Content = currentUser.Nombre+" "+currentUser.Apellidos;
            Correo.Content = currentUser.Correo;
            Phone.Content = currentUser.Telefono;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassForm chpass = new ChangePassForm(DependencyRegister._userService, currentUser.Id);
            chpass.ShowDialog();
        }
    }
}
