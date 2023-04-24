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
        public static readonly StyledProperty<UserControl> CurrentViewProperty =
            AvaloniaProperty.Register<AppShell, UserControl>(nameof(CurrentView), defaultValue: null, notifying: OnCurrentViewChanged);

        public UserControl CurrentView { get => GetValue<UserControl>(CurrentViewProperty); set => SetValue(CurrentViewProperty, value); }

        public AppShell()
        {
            InitializeComponent();
        }

        private void OnMenuClicked(object sender,TappedEventArgs args)
        {
            Menu.IsOpen = !Menu.IsOpen;
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
