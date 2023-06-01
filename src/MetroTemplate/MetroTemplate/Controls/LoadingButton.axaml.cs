using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace MetroTemplate.Controls
{
    public class LoadingButton : Button
    {
        public static readonly StyledProperty<bool> IsLoadingProperty =
            AvaloniaProperty.Register<LoadingButton, bool>(nameof(IsLoading), defaultValue: false);

        public bool IsLoading { get => GetValue(IsLoadingProperty); set => SetValue(IsLoadingProperty, value); }
    }
}
