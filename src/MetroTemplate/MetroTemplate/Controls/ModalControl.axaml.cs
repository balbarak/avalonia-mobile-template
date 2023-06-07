using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Metadata;

namespace MetroTemplate.Controls
{
    public class ModalControl : TemplatedControl
    {
        public static readonly StyledProperty<object> ContentProperty =
           AvaloniaProperty.Register<ModalControl, object>(nameof(Content), defaultValue: null);

        public static readonly StyledProperty<bool> IsOpenProperty =
           AvaloniaProperty.Register<ModalControl, bool>(nameof(IsOpen), defaultValue: false);

        [Content]
        public object Content { get => GetValue(ContentProperty); set => SetValue(ContentProperty, value); }

        public bool IsOpen { get => GetValue(IsOpenProperty); set => SetValue(IsOpenProperty, value); }


    }
}
