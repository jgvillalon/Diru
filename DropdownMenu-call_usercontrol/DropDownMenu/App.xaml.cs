using DIRU.Dependencies;
using DIRU.Views.Loggin;
using DropDownMenu.Views.Loggin;
using Entity;
using System;
using System.Configuration;
using System.Windows;
using ISession = NHibernate.ISession;

namespace DropDownMenu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary'   
    public partial class App : Application
  {
        private ISession _session;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); // Add an Application Setting.

            bool isInstalledProperty = bool.Parse(ConfigurationManager.AppSettings["isInstalled"]);

            try
            {
                Connection conexion = new Connection();
                if (_session == null || !_session.IsConnected)
                {
                    _session = conexion.Open();

                    DependencyRegister.Inject(_session);
                }
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                {
                    isInstalledProperty = false;
                  
                }
            }


            if (isInstalledProperty) 
                new Login().Show();
            else
                new InstallDatabase().Show();



        }














        // public  ISession _session;
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    ServiceCollection services = new ServiceCollection();
        //    services.AddScoped<Login>();
        //    services.AddScoped<MainWindow>();







        //    services.AddScoped<IProyectoService, ProyectoService>();
        //    services.AddScoped<IProyectoRepository, ProyectoRepository>();
        //    services.AddScoped<IUserRepository, UserRepository>();
        //    services.AddScoped<IUserService, UserService>();
        //    services.AddScoped<ILicenseRepository, LicenseRepository>();
        //    services.AddScoped<ILicenseService, LicenseService>();

        //    //services.AddScoped<UserControlMenuItem>();
        //    //services.AddScoped<UserControlProviders>();
        //    //services.AddScoped<ManageUser>();
        //    //services.AddScoped<ChangePassForm>();
        //    //services.AddScoped<UserForm>();
        //    //services.AddScoped<ScaleInterfacePage>();
        //    //services.AddScoped<IJMDataIntegration, JMDataIntegration>();
        //    //services.AddScoped<IBalanceIntegrationContext, BalanceIntegrationContext>();
        //    //services.AddScoped<IScale>(provider => new Scale("1234"));
        //    //services.AddScoped<ScaleIntegrationViewModel>();

        //    ServiceProvider serviceProvider = services.BuildServiceProvider();
        //    Login loginWindow = serviceProvider.GetService<Login>();
        //    loginWindow.Show();

        //}

        //private void CreateConfigFile(DatabaseConfig databaseConfigs)
        //{


        //    var fileFormat = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
        //    <hibernate-configuration xmlns=""urn:nhibernate-configuration-2.2"">
        //      <session-factory>
        //        <property name=""connection.connection_string"">
        //          Server = {0}; Database = {1}; User ID = {2} ; Password = ""{3}"";
        //        </property>
        //        <property name=""connection.driver_class"">NHibernate.Driver.NpgsqlDriver</property>
        //        <property name=""dialect"">NHibernate.Dialect.PostgreSQL82Dialect</property>
        //        <property name=""hbm2ddl.keywords"">auto-quote</property>
        //        <property name=""hbm2ddl.auto"">update</property>
        //        <property name=""current_session_context_class"">thread</property>


        //      </session-factory>
        //    </hibernate-configuration> ";
        //    var fileContents = string.Format(fileFormat, databaseConfigs.Server, databaseConfigs.DatabaseName, databaseConfigs.DatabaseUser, databaseConfigs.Password);


        //    File.WriteAllText(@"hibernate.cfg.xml", fileContents);
        //}



    }

    public class DatabaseConfig
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string DatabaseUser { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }

    }
}
