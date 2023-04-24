using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Animators;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;
using Microsoft.Extensions.Logging.Console;
using System;

namespace MetroTemplate.Controls;

public class HamburgerMenu : TemplatedControl
{
    private Border _border;
    private Grid _container;
    private Rectangle _backdrop;

    private ControlAnimator _openAnimator;
    private ControlAnimator _closeAnimator;
    private ControlAnimator _backdropAnimator;

    private double _menuWidth;

    public static readonly StyledProperty<bool> IsOpenProperty =
        AvaloniaProperty.Register<HamburgerMenu, bool>(nameof(IsOpen), defaultValue: false, notifying: OnIsOpenPropertyChanged);

    public static readonly StyledProperty<object> ContentProperty =
        AvaloniaProperty.Register<HamburgerMenu, object>(nameof(IsOpen), defaultValue: null);

    public static readonly StyledProperty<double> MenuPositionXProperty =
        AvaloniaProperty.Register<HamburgerMenu, double>(nameof(MenuPositionX), defaultValue: 0);

    public bool IsOpen { get => GetValue<bool>(IsOpenProperty); set => SetValue(IsOpenProperty, value); }

    public object Content { get => GetValue<object>(ContentProperty); set => SetValue(ContentProperty, value); }
    public double MenuPositionX { get => GetValue<double>(MenuPositionXProperty); set => SetValue(MenuPositionXProperty, value); }

    public HamburgerMenu()
    {
        _openAnimator = new ControlAnimator(TimeSpan.FromSeconds(.2));
        _closeAnimator = new ControlAnimator(TimeSpan.FromSeconds(.2));
        _backdropAnimator = new ControlAnimator(TimeSpan.FromSeconds(.2));
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _border = e.NameScope.Find<Border>("PART_Border");
        _container = e.NameScope.Find<Grid>("PART_Container");

        _backdrop = e.NameScope.Find<Rectangle>("PART_Backdrop");

        _backdrop.Tapped += (s, e) =>
        {
            IsOpen = false;
        };
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        _menuWidth = (availableSize.Width / 100) * 70;

        if (_menuWidth > 450)
            _menuWidth = 450;

        if (MenuPositionX == 0)
            MenuPositionX = -_menuWidth;

        if (_border != null)
            _border.Width = _menuWidth;

        return base.MeasureOverride(availableSize);
    }

    private void OnIsOpenChanged()
    {
        if (IsOpen)
        {
            OpenWithAnimation();
        }
        else
        {
            CloseWithAnimation();
        }
    }

    private void OpenWithAnimation()
    {
        _backdrop.Opacity = 0;
        _backdrop.IsVisible = true;

        _backdropAnimator.StartAnimation(.6, _backdrop, Rectangle.OpacityProperty);
        _openAnimator.StartAnimation(_menuWidth, this, HamburgerMenu.MenuPositionXProperty);
    }

    private void CloseWithAnimation()
    {
        _closeAnimator.StartAnimation(-_menuWidth, this, HamburgerMenu.MenuPositionXProperty);
        _backdropAnimator.StartAnimation(-1, _backdrop, Rectangle.OpacityProperty);
    }

    private static void OnIsOpenPropertyChanged(IAvaloniaObject arg1, bool arg2)
    {
        if (arg1 is HamburgerMenu menu && arg2)
        {
            menu.OnIsOpenChanged();
        }
    }

}

