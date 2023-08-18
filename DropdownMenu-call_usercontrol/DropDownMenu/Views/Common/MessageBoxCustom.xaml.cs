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
    /// Interaction logic for MessageBoxCustom.xaml
    /// </summary>
    public partial class MessageBoxCustom : Window
    {
        public MessageBoxCustom(string Message, MessageType Type, MessageButtons Buttons)
        {
            InitializeComponent();
            txtMessage.Text = Message;
            switch (Type)
            {

                case MessageType.Info:
                    txtTitle.Text = "Info";
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Information;
                    MessageIcon.Foreground = Brushes.Blue;
                    break;
                case MessageType.Confirmation:
                    txtTitle.Text = "Confirmation";
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.QuestionMarkCircle;
                    MessageIcon.Foreground = Brushes.Blue;
                    break;
                case MessageType.Success:
                    {
                        txtTitle.Text = "Success";
                        MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Information;
                        MessageIcon.Foreground = Brushes.Green;
                    }
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Warning";
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Warning;
                    MessageIcon.Foreground = Brushes.Yellow;
                    break;
                case MessageType.Error:
                    {
                        txtTitle.Text = "Error";
                        MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                        MessageIcon.Foreground = Brushes.Red;
                    }
                    break;
            }
            switch (Buttons)
            {
                case MessageButtons.OkCancel:
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.YesNo:
                    btnOk.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Ok:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
    public enum MessageType
    {
        Info,
        Confirmation,
        Success,
        Warning,
        Error,
    }
    public enum MessageButtons
    {
        OkCancel,
        YesNo,
        Ok,
    }
}
