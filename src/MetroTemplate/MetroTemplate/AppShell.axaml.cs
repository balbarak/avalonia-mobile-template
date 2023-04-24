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
            AvaloniaProperty.Register<AppShell, UserControl>(nameof(CurrentView), defaultValue: null,coerce: OnCurrentViewChanged);

       
        public UserControl CurrentView { get => GetValue<UserControl>(CurrentViewProperty); set => SetValue(CurrentViewProperty, value); }

        public AppShell()
        {
            InitializeComponent();
        }

        private void OnMenuClicked(object sender,TappedEventArgs args)
        {
            Menu.IsOpen = !Menu.IsOpen;
        }

        private void OnViewChanged(UserControl newView)
        {
            if (Menu.IsOpen)
                Menu.IsOpen = false;
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
