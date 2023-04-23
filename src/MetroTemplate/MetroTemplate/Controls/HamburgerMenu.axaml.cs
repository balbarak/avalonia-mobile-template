using Avalonia;
using Avalonia.Animation.Animators;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;

namespace MetroTemplate.Controls;

public class HamburgerMenu : TemplatedControl
{
    private Border _border;
    private ControlAnimator _openAnimator;
    private ControlAnimator _closeAnimator;

    public static readonly StyledProperty<bool> IsOpenProperty =
        AvaloniaProperty.Register<HamburgerMenu, bool>(nameof(IsOpen), defaultValue: false,notifying: OnIsOpenPropertyChanged);

    public static readonly StyledProperty<object> ContentProperty =
        AvaloniaProperty.Register<HamburgerMenu, object>(nameof(IsOpen), defaultValue: null);

    public bool IsOpen { get => GetValue<bool>(IsOpenProperty); set => SetValue(IsOpenProperty, value); }

    public object Content { get => GetValue<object>(ContentProperty); set => SetValue(ContentProperty, value); }

    public HamburgerMenu()
    {
        _openAnimator = new ControlAnimator(400, TimeSpan.FromSeconds(.3));
        _closeAnimator = new ControlAnimator(0, TimeSpan.FromSeconds(.3));
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        _border = e.NameScope.Find<Border>("PART_Border");
        _border.Width = 0;
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
        _openAnimator.StartAnimation(_border, Border.WidthProperty);
    }

    private void CloseWithAnimation()
    {
        _closeAnimator.StartAnimation(_border, Border.WidthProperty);
    }

    private static void OnIsOpenPropertyChanged(IAvaloniaObject arg1, bool arg2)
    {
        if (arg1 is HamburgerMenu menu && arg2)
        {
            menu.OnIsOpenChanged();
        }
    }
}

