using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using MetroTemplate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MetroTemplate.Views
{
    public partial class AlertView : UserControl
    {
        private ControlAnimator _showAnimator;
        private ControlAnimator _closeAnimator;

        private Rectangle _backdrop;
        private Grid _container;

        public static readonly StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<AlertView, bool>(nameof(IsOpen), defaultValue: false,coerce:OnIsOpenChanged);

        public bool IsOpen { get => GetValue(IsOpenProperty); set => SetValue(IsOpenProperty, value); }

        public string Title { get; set; }

        public string Message { get; set; }

        public AlertView()
        {
            _showAnimator = new ControlAnimator(TimeSpan.FromSeconds(0.3));
            _closeAnimator = new ControlAnimator(TimeSpan.FromSeconds(0.3));

            _closeAnimator.OnAnimationCompleted += OnClosedAnimationCompleted;

            InitializeComponent();
            DataContext = this;

            _backdrop = this.Find<Rectangle>("PART_Backdrop");
            _container = this.Find<Grid>("PART_Container");
        }

        public AlertView(string title,string msg) : this()
        {
            Title = title;
            Message = msg;
        }

        private void OnBackdropClicked(object sender, TappedEventArgs args)
        {
            var nav = App.AppHost.Services.GetService<INavigationService>();

            nav.CloseAlert();
        }

        private void OnViewChanged(bool value)
        {
            if (value)
            {
                _showAnimator.StartAnimation(.6, _backdrop, Rectangle.OpacityProperty);
            }
            else
            {
                _closeAnimator.StartAnimation(0.0, _backdrop, Rectangle.OpacityProperty);
            }
        }

        private static bool OnIsOpenChanged(AvaloniaObject item, bool arg2)
        {
            if (item is AlertView view)
            {
                view.OnViewChanged(arg2);
            }

            return arg2;
        }


        private void OnClosedAnimationCompleted(object sender, EventArgs e)
        {
            this.IsVisible = false;
        }

    }
}
