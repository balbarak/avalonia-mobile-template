using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MetroTemplate.ViewModels
{
    public class ThemeViewModel : ViewModelBase
    {
        private bool _isButtonLoading;

        public bool IsButtonLoading { get => _isButtonLoading; set => SetProperty(ref _isButtonLoading, value); }


        public ICommand LoadingButtonCommand { get; }

        public ThemeViewModel()
        {
            LoadingButtonCommand = new AsyncRelayCommand(async () =>
            {
                IsButtonLoading = true;
                await Task.Delay(3000);
                IsButtonLoading = false;
            });
        }
    }
}
