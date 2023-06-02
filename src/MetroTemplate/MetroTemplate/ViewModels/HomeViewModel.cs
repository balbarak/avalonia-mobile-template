using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MetroTemplate.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand GoToSecondViewCommand { get; }

        public HomeViewModel()
        {
            GoToSecondViewCommand = new AsyncRelayCommand(_navService.NavigateTo<SecondViewModel>);   
        }
    }
}
