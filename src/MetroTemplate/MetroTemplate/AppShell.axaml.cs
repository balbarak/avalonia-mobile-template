using Avalonia.Controls;
using Avalonia.Input;

namespace MetroTemplate
{
    public partial class AppShell : UserControl
    {
        public AppShell()
        {
            InitializeComponent();
            
        }

        private void OnMenuClicked(object sender,TappedEventArgs args)
        {
            Menu.IsOpen = !Menu.IsOpen;
        }
    }
}
