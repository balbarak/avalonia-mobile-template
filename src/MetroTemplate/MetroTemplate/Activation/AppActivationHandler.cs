using Avalonia.Controls.ApplicationLifetimes;
using MetroTemplate.Services;
using MetroTemplate.ViewModels;
using MetroTemplate.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTemplate.Activation
{
    public class AppActivationHandler
    {
        public static async Task Activate(ISingleViewApplicationLifetime app)
        {
            var navService = App.AppHost.Services.GetService<INavigationService>();

            var appShell = App.AppHost.Services.GetService<AppShell>();

            app.MainView = appShell;

            //await navService.GoToView<AppShellViewModel>();
        }

        public static async Task ActivateDesktop(IClassicDesktopStyleApplicationLifetime app)
        {
            var navService = App.AppHost.Services.GetService<INavigationService>();

            var mainView = App.AppHost.Services.GetService<AppShell>();

            app.MainWindow = new MainWindow();
            app.MainWindow.Content = App.AppHost.Services.GetService<AppShell>();

            //await navService.GoToView<AppShellViewModel>();
        }
    }
}
