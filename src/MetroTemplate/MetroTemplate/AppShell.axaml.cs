using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using MetroTemplate.Controls;
using MetroTemplate.ViewModels;
using MetroTemplate.Views;
using System;

namespace MetroTemplate
{
    public partial class AppShell : UserControl
    {
        public static readonly StyledProperty<UserControl> CurrentViewProperty =
            AvaloniaProperty.Register<AppShell, UserControl>(nameof(CurrentView), defaultValue: null,coerce: OnCurrentViewChanged);


        public static readonly StyledProperty<AlertView> AlertViewProperty =
            AvaloniaProperty.Register<AppShell, AlertView>(nameof(Alert), defaultValue: null);


        public UserControl CurrentView { get => GetValue(CurrentViewProperty); set => SetValue(CurrentViewProperty, value); }

        public AlertView Alert { get => GetValue(AlertViewProperty); set => SetValue(AlertViewProperty, value); }

        public AppShellViewModel ViewModel => DataContext as AppShellViewModel;

        public AppShell()
        {
            InitializeComponent();
        }

        private void OnMenuClicked(object sender,TappedEventArgs args)
        {
            split.IsPaneOpen = !split.IsPaneOpen;
        }


        private void OnViewChanged(UserControl newView)
        {
            if (split.IsPaneOpen)
                split.IsPaneOpen = false;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            split.OpenPaneLength = (availableSize.Width / 100) * 70;
            
            return base.MeasureOverride(availableSize);
        }

        private static UserControl OnCurrentViewChanged(AvaloniaObject arg1, UserControl value)
        {
            if (arg1 is AppShell appShell)
            {
                appShell.OnViewChanged(value);
            }

            return value;
        }
    }
}
