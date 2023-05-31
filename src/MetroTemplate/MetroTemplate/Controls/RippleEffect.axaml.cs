using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace MetroTemplate.Controls
{
    public class RippleEffect : ContentControl
    {
        public static readonly StyledProperty<IBrush> RippleFillProperty =
            AvaloniaProperty.Register<RippleEffect, IBrush>(nameof(RippleFill), defaultValue: null);

        public static readonly StyledProperty<double> RippleOpacityProperty =
            AvaloniaProperty.Register<RippleEffect, double>(nameof(RippleOpacity), defaultValue: 0);


        private Ellipse _circle;
        private Animation _ripple;
        private Point _pointer;
        private IAnimationSetter _toWidth;
        private IAnimationSetter _fromMargin;
        private IAnimationSetter _toMargin;
        private bool _isRunning;

        public IBrush RippleFill { get => GetValue(RippleFillProperty); set => SetValue(RippleFillProperty, value); }

        public double RippleOpacity { get => GetValue(RippleOpacityProperty); set => SetValue(RippleOpacityProperty, value);  }

        public RippleEffect()
        {
            this.AddHandler(PointerPressedEvent, async (s, e) =>
            {
                if (_isRunning)
                {
                    return;
                }

                _pointer = e.GetPosition(this);
                _isRunning = true;

                var maxWidth = Math.Max(Bounds.Width, Bounds.Height) * 2.2D;

                _toWidth.Value = maxWidth;
                _fromMargin.Value = _circle.Margin = new Thickness(_pointer.X, _pointer.Y, 0, 0);
                _toMargin.Value = new Thickness(_pointer.X - maxWidth / 2, _pointer.Y - maxWidth / 2, 0, 0);

                await _ripple.RunAsync(_circle, null);

                _isRunning = false;
            });
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _circle = e.NameScope.Find<Ellipse>("Circle");

            var style = _circle.Styles[0] as Style;
            _ripple = style.Animations[0] as Animation;
            _toWidth = _ripple.Children[1].Setters[1];
            _fromMargin = _ripple.Children[0].Setters[0];
            _toMargin = _ripple.Children[1].Setters[0];

            style.Animations.Remove(_ripple);
        }


    }
}

