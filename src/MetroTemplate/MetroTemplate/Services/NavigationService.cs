using Avalonia.Controls;
using MetroTemplate.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTemplate.Services
{
    public class NavigationService : INavigationService
    {
        public static IDictionary<Type, Type> PageMapping { get; private set; } = new Dictionary<Type, Type>();

        public IServiceProvider Services => App.AppHost.Services;

        public async Task GoToView<TViewModel>() where TViewModel : ViewModelBase
        {
            PageMapping.TryGetValue(typeof(TViewModel), out var pageType);

            var shell = Services.GetService<AppShell>();
            var page = Services.GetService(pageType) as UserControl;
            var viewModel = page.DataContext as ViewModelBase;

            await viewModel.OnAppearing();

            shell.CurrentView = page;

        }
    }
}
