using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MetroTemplate.ViewModels
{
    public class ModalViewModel : ViewModelBase
    {
        public ICommand OpenAlertCommand { get; }


        public ModalViewModel()
        {
            OpenAlertCommand = new AsyncRelayCommand(async()=> await _navService.ShowAlert("Hi","Test"));

        }
    }
}
