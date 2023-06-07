using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using MetroTemplate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MetroTemplate.Views
{
    public partial class AlertView : UserControl
    {
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
