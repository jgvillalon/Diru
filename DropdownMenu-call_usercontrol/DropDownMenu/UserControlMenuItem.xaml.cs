using BeautySolutions.View.ViewModel;
using DropDownMenu.Views.InversionLotes;
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

namespace DropDownMenu
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MainWindow _context;
        public UserControlMenuItem(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();

            _context = context;
            
            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;
            //if(itemMenu.SubItems == null)
            //    Icon.Visibility = Visibility.Collapsed;
            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // var items = ListViewMenu.Items;
            
            //_context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
        }

        private void ExpanderMenu_Expanded(object sender, RoutedEventArgs e)
        {
            var items = ListViewMenu.Items;
        }

        private void ListViewMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var item = (ItemMenu)this.DataContext;
            var subItem = item.SubItems.First(s => s.Name.Equals(btn.Content.ToString()));
          
           ListViewMenu.SelectedItem = subItem;
            
            if (subItem.Screen != null && subItem.Screen.GetType().Name.Equals("InversionLoteView")) {
                MainWindow.currentProject = null;
                _context.SwitchScreen(new InversionLoteView());
              
            }
            else
            _context.SwitchScreen(subItem.Screen);
        }

      

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            var item = (ItemMenu)this.DataContext;
            ListViewItemMenu.IsSelected = true;
            _context.SwitchScreen(item.Screen);
        }
    }
}
