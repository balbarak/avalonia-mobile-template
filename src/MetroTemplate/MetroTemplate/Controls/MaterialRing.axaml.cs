using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace MetroTemplate.Controls
{
    public class MaterialRing : TemplatedControl
    {
        public static readonly StyledProperty<bool> IsRunningProperty =
            AvaloniaProperty.Register<MaterialRing, bool>(nameof(IsRunning), defaultValue: false);


        public static readonly StyledProperty<IBrush> ColorProperty =
            AvaloniaProperty.Register<MaterialRing, IBrush>(nameof(Color), defaultValue: null);

        public IBrush Color { get => GetValue(ColorProperty); set => SetValue(ColorProperty, value); }

        public bool IsRunning { get => GetValue(IsRunningProperty); set => SetValue(IsRunningProperty, value); }
    }
}
