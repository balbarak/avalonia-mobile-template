using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using MetroTemplate.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MetroTemplate.Views
{
    public partial class AlertView : UserControl
    {
        public static readonly StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<AlertView, bool>(nameof(IsOpen), defaultValue: true);

        public bool IsOpen { get => GetValue(IsOpenProperty); set => SetValue(IsOpenProperty, value); }

        public string Title { get; set; }

        public string Message { get; set; }

        public AlertView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public AlertView(string title,string msg) : this()
        {
            Title = title;
            Message = msg;
        }

        private void OnBackdropClicked(object sender, TappedEventArgs args)
        {
            var nav = App.AppHost.Services.GetService<INavigationService>();

            nav.CloseAlert();
        }
    }
}
