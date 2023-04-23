using Avalonia.Controls;
using MetroTemplate.Services;
using MetroTemplate.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTemplate
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPageTransient<TViewModel, TView>(this IServiceCollection services)
            where TViewModel : ViewModelBase
            where TView : UserControl, new()
        {
            services.AddTransient(typeof(TViewModel));

            services.AddTransient<TView>(provider =>
            {
                var viewModel = provider.GetService<TViewModel>();

                var view = new TView
                {
                    DataContext = viewModel
                };

                return view;
            });

            NavigationService.PageMapping.Add(typeof(TViewModel), typeof(TView));
        }

        public static void AddPageSingleton<TViewModel, TView>(this IServiceCollection services)
            where TViewModel : ViewModelBase
            where TView : UserControl, new()
        {
            services.AddSingleton(typeof(TViewModel));

            services.AddSingleton<TView>(provider =>
            {
                var viewModel = provider.GetService<TViewModel>();

                var view = new TView
                {
                    DataContext = viewModel
                };

                return view;
            });

            NavigationService.PageMapping.Add(typeof(TViewModel), typeof(TView));
        }
    }
}
