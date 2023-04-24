using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using MetroTemplate.Controls;
using System;

namespace MetroTemplate
{
    public partial class AppShell : UserControl
    {
        public static readonly StyledProperty<object> CurrentViewProperty =
            AvaloniaProperty.Register<AppShell, object>(nameof(CurrentView), defaultValue: null, notifying: OnCurrentViewChanged);

        public object CurrentView { get => GetValue<object>(CurrentViewProperty); set => SetValue(CurrentViewProperty, value); }

        public AppShell()
        {
            InitializeComponent();
        }

        private void OnMenuItemTapped(object sender,TappedEventArgs args)
        {
            Menu.IsOpen = false;
        }

        private void OnViewChanged()
        {
            if (Menu.IsOpen)
                Menu.IsOpen = false;
        }

        private static void OnCurrentViewChanged(IAvaloniaObject arg1, bool arg2)
        {
            if (arg1 is AppShell appshell && arg2)
            {
                appshell.OnViewChanged();
            }
        }
    }
}
