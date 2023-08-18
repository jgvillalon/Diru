using DIRU.Dependencies;
using DIRU.Views.Common;
using Entity;
using NHibernate;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DropDownMenu.Views.Loggin
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string CaptchaValue { get; set; }
        private ISession _session;

        public event System.EventHandler CaptchaRefreshed;
        public Login()
        {
            InitializeComponent();
            CaptchaGenerator();
        }
        //  public bool IsDarkTheme { get; set; }
        // private readonly PaletteHelper paletteHelper = new PaletteHelper();
        //===================================>
        private void OnLoad(object sender, RoutedEventArgs e)
        {

           

                /*Validar licencia*/
                //var license = DependencyRegister._licenseService.GetLicense();
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
                //    else if (fecha_exp.Date.Subtract(DateTime.Today.Date).TotalDays > 0 && fecha_exp.Date.Subtract(DateTime.Today.Date).TotalDays <= 10)
                //        new MessageBoxCustom("Su licencia expira en " + fecha_exp.Date.Subtract(DateTime.Today.Date).TotalDays.ToString("0") + " días", MessageType.Warning, MessageButtons.Ok).ShowDialog();

                //    else if (fecha_exp.Date.Subtract(DateTime.Today.Date).TotalDays == 0)

                //    new MessageBoxCustom("Su licencia expira mañana", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                //    DIRU.Properties.Settings.Default.expireLicense = fecha_exp;
                //    DIRU.Properties.Settings.Default.Save();
                //}

                //else
                //{
                //   new MessageBoxCustom("Licencia requerida", MessageType.Error, MessageButtons.Ok).ShowDialog();
                //    this.Close();
                //}

                 // }

            }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            DIRU.Properties.Settings.Default.username = txt_user.Text;
            DIRU.Properties.Settings.Default.Save();
            MainWindow principal = new MainWindow();
            principal.Show();
            this.Close();

            //try
            //{

            //    if (txt_user.Text != "" && txt_pass.Password != "" && txt_captcha.Text != "")
            //    {
            //        if (!txt_captcha.Text.ToLower().Equals(CaptchaText.Text.ToLower()))
            //        {
            //            new MessageBoxCustom("Captcha incorrecto", MessageType.Error, MessageButtons.Ok).ShowDialog();
            //            txt_captcha.BorderBrush = Brushes.Red;

            //        }

            //        else
            //        {

            //            if (_session == null || !_session.IsConnected)
            //            {
            //                Connection conexion = new Connection();
            //                _session = conexion.Open();

            //                DependencyRegister.Inject(_session);

            //            }

            //            if (DependencyRegister._userService.Login(txt_user.Text, txt_pass.Password))
            //            {
            //                DIRU.Properties.Settings.Default.username = txt_user.Text;
            //                DIRU.Properties.Settings.Default.Save();
            //                MainWindow principal = new MainWindow();
            //                principal.ShowDialog();
            //            }
            //            else
            //                new MessageBoxCustom("Credenciales incorrectas", MessageType.Error, MessageButtons.Ok).ShowDialog();
            //        }
            //    }
            //    else new MessageBoxCustom("Existen campos vacíos", MessageType.Error, MessageButtons.Ok).ShowDialog();
            //}
            //catch (Exception)
            //{
            //    new MessageBoxCustom("Ha ocurrido un error", MessageType.Error, MessageButtons.Ok).ShowDialog();

            //}

        }

        private void CaptchaGenerator()
        {

            string allowchar = string.Empty;
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            string pwd = string.Empty;
            string temp = string.Empty;
            System.Random r = new System.Random();

            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];

                pwd += temp;
            }

            CaptchaText.Text = pwd;

            CaptchaValue = CaptchaText.Text;

            CaptchaRefreshed?.Invoke(this, System.EventArgs.Empty);

        }

        private void ResetCaptchaButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CaptchaGenerator();
        }

        private void Card_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)

                LoginBtn_Click(null, null);
        }


    }
}

