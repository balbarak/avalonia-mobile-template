using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Threading;
using MetroTemplate.Animations;
using MetroTemplate.ViewModels;
using MetroTemplate.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetroTemplate.Services
{
    public class NavigationService : INavigationService
    {
        private Stack<UserControl> _navigationStack;
        private UserControl _lastPage;
        private TimeSpan _speed;

        public static IDictionary<Type, Type> PageMapping { get; private set; } = new Dictionary<Type, Type>();

        public IServiceProvider Services => App.AppHost.Services;

        public NavigationService()
        {
            _speed = TimeSpan.FromSeconds(.3);
            _navigationStack = new Stack<UserControl>();
        }

        public async Task GoToView<TViewModel>() where TViewModel : ViewModelBase
        {
            PageMapping.TryGetValue(typeof(TViewModel), out var pageType);

            var shell = Services.GetService<AppShell>();
            var page = Services.GetService(pageType) as UserControl;
            var viewModel = page.DataContext as ViewModelBase;

            shell.ContentTrans.PageTransition = new CrossFade(_speed);

            await viewModel.OnAppearing();

            shell.CurrentView = page;
        }

        public async Task NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            PageMapping.TryGetValue(typeof(TViewModel), out var pageType);

            var shell = Services.GetService<AppShell>();
            var page = Services.GetService(pageType) as UserControl;
            var viewModel = page.DataContext as ViewModelBase;
            var shellViewModel = shell.DataContext as AppShellViewModel;
            
            _navigationStack.Push(page);

            await viewModel.OnAppearing();

            _lastPage = shell.CurrentView;

            shell.ContentTrans.PageTransition = new PageSlide(_speed);

            shell.CurrentView = page;
            shell.ShowBackButton = true;
        }

        public async Task GoBack()
        {
            var hasPage = _navigationStack.TryPop(out var currentPage);
            var shell = Services.GetService<AppShell>();
            var shellViewModel = shell.DataContext as AppShellViewModel;

            if (!hasPage)
                return;

            shell.ContentTrans.PageTransition = new ReversePageSlide(_speed);

            var hasPrevPage = _navigationStack.TryPop(out var prevPage);

            if (hasPrevPage)
            {
                var viewModel = prevPage.DataContext as ViewModelBase;

                shell.CurrentView = prevPage;

                await viewModel.OnAppearing();
            }
            else
            {
                shell.CurrentView = _lastPage;

                if (_lastPage != null)
                {
                    var lastPageViewModel = _lastPage.DataContext as ViewModelBase;

                    await lastPageViewModel.OnAppearing();
                }
            }

            shell.ShowBackButton = _navigationStack.Count > 0;
        }

        public async Task ShowAlert(string title, string msg)
        {
            Dispatcher.UIThread.Invoke(() =>
            {
                var alert = new AlertView(title, msg);
                var shell = Services.GetService<AppShell>();

                shell.Alert = alert;
                alert.IsOpen = true;
            });

        }

        public void CloseAlert()
        {
            Dispatcher.UIThread.Invoke(() =>
            {
                var shell = Services.GetService<AppShell>();

                var alert = shell.Alert;

                if (alert == null)
                    return;

                alert.IsOpen = false;
            });


            //shell.Alert = null;
        }
    }
}
