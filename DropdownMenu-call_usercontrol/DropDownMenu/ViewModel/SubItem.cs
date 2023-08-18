using System.Windows.Controls;

namespace BeautySolutions.View.ViewModel
{
    public class SubItem
    {
        public SubItem(string name, string fullname, UserControl screen = null)
        {
            Name = name;
            FullName = fullname;
            Screen = screen;
        }
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public UserControl Screen { get; private set; }
    }
}