using DIRU.Dependencies;
using DIRU.Views.Common;
using DropDownMenu;
using Entity;
using Entity.Entitys;
using Npgsql;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Globalization;
using Entity.Entitys.Nomencladores.Generales;
using NHibernate.Engine;
using DropDownMenu.Views.Loggin;
using Entity.Entitys.Seguridad;
using Entity.Entitys.Proyectos.InversionesLotes;

namespace DIRU.Views.Loggin
{
    /// <summary>
    /// Interaction logic for InstallDatabase.xaml
    /// </summary>
    public partial class InstallDatabase : Window
    {
        public InstallDatabase()
        {
            InitializeComponent();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            if (txt_host.Text != "" && txt_port.Text != "" && txt_userp.Text != "" && txt_passp.Password != "" && txt_bdname.Text != "")
            {
                string connStr = "Server=" + txt_host.Text + ";Port=" + txt_port.Text + ";User Id=" + txt_userp.Text + ";Password=" + txt_passp.Password + ";";

                NpgsqlConnection cn = new NpgsqlConnection(connStr);
                try
                {
                    cn.Open();
                    cn.Close();
                    BtnTest.Background = Brushes.Green;
                    new MessageBoxCustom("Conexión establecida correctamente", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    

                }
                catch (Exception)
                {
                    BtnTest.Background = Brushes.Red;
                    new MessageBoxCustom("No es posible establecer conexión", MessageType.Error, MessageButtons.Ok).ShowDialog();
                   

                }


            }
        }
        
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txt_host.Text != "" && txt_port.Text != "" && txt_userp.Text != "" && txt_passp.Password != "" && txt_bdname.Text != "")
            {
                string connStr = "Server=" + txt_host.Text + ";Port=" + txt_port.Text + ";User Id=" + txt_userp.Text + ";Password=" + txt_passp.Password + ";";

                bool existDb = false;
                NpgsqlConnection cn = new NpgsqlConnection(connStr);
                cn.Open();
                string data = "SELECT datname FROM pg_catalog. pg_database WHERE lower(datname) = lower('" + txt_bdname.Text + "')";
                NpgsqlCommand command = new NpgsqlCommand(data, cn);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    existDb = true;


                }
                cn.Close();

                if (!existDb)
                {

                    var m_createdb_cmd = new NpgsqlCommand(@"CREATE DATABASE " + txt_bdname.Text + "  WITH OWNER = postgres ENCODING = 'UTF8'CONNECTION LIMIT = -1;", cn);
                    cn.Open();
                    await m_createdb_cmd.ExecuteNonQueryAsync();
                    cn.Close();

                }  

                    DatabaseConfig databaseConfig = new DatabaseConfig
                    {
                        Server = txt_host.Text,
                        DatabaseName = txt_bdname.Text,
                        DatabaseUser = txt_userp.Text,
                        Password = txt_passp.Password,
                        Port = txt_port.Text
                    };

                    DependencyRegister.CreateConfigFile(databaseConfig);

                    Connection conexion = new Connection();
                try { 
                    DependencyRegister.Inject(conexion.Open());
                    }
                catch (Exception ex)
                {
                    new MessageBoxCustom("Ha ocurrido un error", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                    /*Add user*/
                    var isInsert = true;
                    var superadmin = DependencyRegister._userService.GetUserbyId(1);
                    if (superadmin == null)
                    {
                        User user = new User
                        {
                            Apellidos = "Admin",
                            Nombre = "Admin",
                            Password = "admin",
                            Username = "admin",
                            Active = true

                        };

                        UserRole role = new UserRole
                        {
                            User = user,
                            Role = Role.SuperAdministrador
                        };
                        user.UserRole = role;
                        isInsert = DependencyRegister._userService.InsertUser(user).Status.Equals(StatusResponse.OK) ? true : false;

                        var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                       .Select(x => new RegionInfo(x.LCID))
                       .GroupBy(x => x.DisplayName)
                       .Select(x => x.First())
                       .OrderBy(x => x.DisplayName)
                       .Select(x => new Pais { Nombre = x.DisplayName, Active = true })
                       .ToList();
                        foreach (var country in countries)
                        {
                            isInsert = DependencyRegister._paisService.InsertPais(country).Status.Equals(StatusResponse.OK) ? true : false;
                        }


                        //Agregar Redes
                        
                        isInsert = DependencyRegister._redService.InsertRed(new Red { Nombre = "Red Sanitaria" }).Status.Equals(StatusResponse.OK) ? true : false;
                        
                        isInsert = DependencyRegister._redService.InsertRed(new Red { Nombre = "Red Drenaje" }).Status.Equals(StatusResponse.OK) ? true : false;
                         
                        isInsert = DependencyRegister._redService.InsertRed(new Red { Nombre = "Red Eléctrica" }).Status.Equals(StatusResponse.OK) ? true : false;
                        
                        isInsert = DependencyRegister._redService.InsertRed(new Red { Nombre = "Red Telefónica" }).Status.Equals(StatusResponse.OK) ? true : false;
                        
                        isInsert = DependencyRegister._redService.InsertRed(new Red { Nombre = "Red Hidraúlica" }).Status.Equals(StatusResponse.OK) ? true : false;
                        
                        isInsert = DependencyRegister._redService.InsertRed(new Red { Nombre = "Red Gas" }).Status.Equals(StatusResponse.OK) ? true : false;
                    

                }
                    //Insertar por defecto la AppVersion


                    if (isInsert)
                    {
                        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["isInstalled"].Value = "true";
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        new Login().Show();
                        Close();
                    }
                    
                     else new MessageBoxCustom("Ha ocurrido un error", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    
                    /*Validar licencia*/
                  //  var license = DependencyRegister._licenseService.GetLicense();
                    //if (license != null)
                    //{
                    //    DateTime fecha_exp;

                    //    if (license.Tipo == 1)
                    //        fecha_exp = DateTime.Parse(license.Encrypt_Date).AddDays(30);

                    //    else if (license.Tipo == 2)
                    //        fecha_exp = DateTime.Parse(license.Encrypt_Date).AddDays(365);

                    //    else
                    //        fecha_exp = DateTime.Parse(license.Encrypt_Date).AddYears(200);

                    //    if (fecha_exp < DateTime.Today)
                    //    {
                    //        new MessageBoxCustom("Su licencia está obsoleta desde :" + fecha_exp.ToString("dd/MM/yyyy") + "", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    //        this.Close();
                    //    }


                    //}

                    //else
                    //{
                    //    new MessageBoxCustom("Licencia requerida", MessageType.Error, MessageButtons.Ok).ShowDialog();
                    //    this.Close();
                    //}
                
            }
            else new MessageBoxCustom("Existen campos vacíos", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
    }
}
