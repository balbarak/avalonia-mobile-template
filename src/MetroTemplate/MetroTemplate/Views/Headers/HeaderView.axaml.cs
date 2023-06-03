using Avalonia.Controls;
using Avalonia.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MetroTemplate.Views
{
    public partial class HeaderView : UserControl
    {
        private AppShell _shell;

        public HeaderView()
        {
            InitializeComponent();

            _shell = App.AppHost.Services.GetService<AppShell>();
        }

        private void OnMenuClicked(object sender, TappedEventArgs args)
        {
            //_shell.IsPaneOpen = true;
        }
    }
}
