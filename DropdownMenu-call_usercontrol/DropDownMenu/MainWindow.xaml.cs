using ApplicationService.IServices;
using ApplicationService.Service;
using BeautySolutions.View.ViewModel;
using DIRU.Dependencies;
using DIRU.Properties;
using DIRU.Views.Administracion.Users;
using DIRU.Views.CargarProyectos;
using DIRU.Views.Common;
using DIRU.Views.Nomencladores.Economicos;
using DIRU.Views.Nomencladores.Geograficos;
using DIRU.Views.Nomencladores.Otros;
using DIRU.Views.RegulacionesUrbanas;
using DropDownMenu.Views.InversionLotes;
using DropDownMenu.Views.Nomencladores;
using Entity.Entitys;
using Entity.Entitys.Proyectos;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DropDownMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      //  public readonly IUserService _userService;
        public static User currentUser { get; set; }
        public static Proyecto currentProject { get; set; }
        public static MenuItem menuGenerales { get; set; }
        public static Grid MainView { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //Type objType = typeof(UserService);
            //Type minterface = objType.GetInterface("IUserService").GetMethods(); 

            MainView = StackPanelMain;
          currentUser = DependencyRegister._userService.GetUserbyUsername(Settings.Default.username);
        //   currentUser = _userService.GetUserbyUsername(Settings.Default.username);
            if (currentUser != null)
            {
               UserAcount.Text = currentUser.Username;

                //if (currentUser.LastProject != null)
                //    currentProject = currentUser.LastProject;




                var toolTip = new ToolTip();
                toolTip.Content = "Expira: " + Settings.Default.expireLicense.ToString("dd/MM/yyyy");
                toolTip.Background = Brushes.ForestGreen;
                toolTip.VerticalAlignment = VerticalAlignment.Top;
                toolTip.Margin = new Thickness(0,0,5,20);
                License.ToolTip = toolTip;

               
            }


            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Inversión por lotes", "Inversión por lotes", new InversionLoteView()));
            menuRegister.Add(new SubItem("Nuevo desarrollo", "Nuevo desarrollo"));
            menuRegister.Add(new SubItem("Regulaciones Urbanas", "Regulaciones Urbanas", new RegulacionUrbana()));
            var item6 = new ItemMenu("Crear Proyecto", menuRegister, PackIconKind.CreateNewFolder);
            var item1 = new ItemMenu("Cargar Proyecto", new LoadProjects(), PackIconKind.FolderUpload);

           

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Generales", "Generales", new NomGenerales()));
            menuExpenses.Add(new SubItem("Económicos", "Económicos", new NomEconomicos()));
            menuExpenses.Add(new SubItem("Geográficos", "Geográficos", new NomGeograficos()));
            menuExpenses.Add(new SubItem("Otros", "Otros", new NomOtros()));
            var item3 = new ItemMenu("Nomencladores", menuExpenses, PackIconKind.Settings);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Manual integrado", "Manual integrado"));
            menuFinancial.Add(new SubItem("Manual Inv. por lotes", "Manual de Inversión por lotes"));
            menuFinancial.Add(new SubItem("Manual Nuevo desarrollo", "Manual de Nuevo desarrollo"));
            menuFinancial.Add(new SubItem("Manual Reg. urbana", "Manual de Regeneración urbana"));
            menuFinancial.Add(new SubItem("Versión del sistema", "Versión del sistema"));
            var item4 = new ItemMenu("Soporte", menuFinancial, PackIconKind.FileReport);

            var item0 = new ItemMenu("Inicio", new UserControlProviders(), PackIconKind.ViewDashboard);

            var menuAdministracion = new List<SubItem>();
            menuAdministracion.Add(new SubItem("Usuarios", "Usuarios", new ManageUser(DependencyRegister._userService)));
           
            var item7 = new ItemMenu("Administración", menuAdministracion, PackIconKind.Settings);

            var role = currentUser.UserRole.Role;
            switch (role)
            {
                case Role.SuperAdministrador:
                    Menu.Children.Add(new UserControlMenuItem(item0, this));
                    Menu.Children.Add(new UserControlMenuItem(item7, this));
                    Menu.Children.Add(new UserControlMenuItem(item6, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));
                    Menu.Children.Add(new UserControlMenuItem(item3, this));
                    Menu.Children.Add(new UserControlMenuItem(item4, this));
                    break;
                case Role.Administrador:
                    Menu.Children.Add(new UserControlMenuItem(item0, this));
                    Menu.Children.Add(new UserControlMenuItem(item7, this));
                    Menu.Children.Add(new UserControlMenuItem(item6, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));
                    Menu.Children.Add(new UserControlMenuItem(item3, this));
                    Menu.Children.Add(new UserControlMenuItem(item4, this));
                    break;
                case Role.Inversionista:
                    Menu.Children.Add(new UserControlMenuItem(item0, this));
                    Menu.Children.Add(new UserControlMenuItem(item6, this));
                    Menu.Children.Add(new UserControlMenuItem(item1, this));
                    Menu.Children.Add(new UserControlMenuItem(item3, this));
                    Menu.Children.Add(new UserControlMenuItem(item4, this));
                    break;
                default:

                    break;
            }


            SwitchScreen(item0.Screen);


        }

   

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            
            if(screen!=null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("¿Está seguro que desa salir? ", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

        if (Result.Value)
            {
                Application.Current.Shutdown();
            }
        }

        private void MyAcount_Click(object sender, RoutedEventArgs e)
        {
            MyUserAcount acount = new MyUserAcount();
            acount.ShowDialog();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
