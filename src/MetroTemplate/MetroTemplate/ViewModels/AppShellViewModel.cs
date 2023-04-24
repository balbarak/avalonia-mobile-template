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
        public ICommand GoToHome { get; }
        public ICommand GoToTheme { get; }

        public AppShellViewModel()
        {
            GoToHome = new AsyncRelayCommand(_navService.GoToView<HomeViewModel>);
            GoToTheme = new AsyncRelayCommand(_navService.GoToView<ThemeViewModel>);
        }

    }
}
