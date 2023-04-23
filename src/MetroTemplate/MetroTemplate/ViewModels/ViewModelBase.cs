using CommunityToolkit.Mvvm.ComponentModel;
using MetroTemplate.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MetroTemplate.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        protected bool _isBusy;
        protected INavigationService _navService;

        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }

        public ViewModelBase()
        {
            _navService = App.AppHost.Services.GetService<INavigationService>();
        }

        public virtual Task OnAppearing()
        {
            return Task.CompletedTask;
        }
    }
}