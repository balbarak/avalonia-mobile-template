using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MetroTemplate.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        private bool _showBackButton;

        public bool ShowBackButton { get => _showBackButton; set => SetProperty(ref _showBackButton, value); }

        public ICommand GoToHome { get; }
        public ICommand GoToTheme { get; }

        public ICommand GoToModal { get; }

        public ICommand GoBackCommand { get; }


        public AppShellViewModel()
        {
            GoToHome = new AsyncRelayCommand(_navService.GoToView<HomeViewModel>);
            GoToTheme = new AsyncRelayCommand(_navService.GoToView<ThemeViewModel>);
            GoToModal = new AsyncRelayCommand(_navService.GoToView<ModalViewModel>);

            GoBackCommand = new AsyncRelayCommand(_navService.GoBack);
        }

    }
}
