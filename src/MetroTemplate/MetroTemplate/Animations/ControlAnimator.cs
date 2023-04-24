using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetroTemplate
{
    public class ControlAnimator : IDisposable
    {
        private DispatcherTimer _timer;
        private TimeSpan _duration;
        private TimeSpan _frameRate;
        private int _currentTick;
        private int _totalTicks;
        private Easing _easing;
        private StyledProperty<double> _property;
        private Control _control;
        private double _from;
        private double _to;

        public static readonly AttachedProperty<double> WidthProperty = AvaloniaProperty.RegisterAttached<Border, Control, double>("Width");

        public ControlAnimator(TimeSpan duration, Easing easing = null)
        {
            _frameRate = TimeSpan.FromSeconds(1 / 120.0);

            _duration = duration;

            if (easing == null)
                _easing = new QuarticEaseIn();
            else
                _easing = easing;

            _totalTicks = (int)(_duration.TotalSeconds / _frameRate.TotalSeconds);

            _timer = new DispatcherTimer()
            {
                Interval = _frameRate
            };

            _timer.Tick += OnTimerTick;
        }


        public void StartAnimation(double targetValue, Control control, StyledProperty<double> property)
        {
            if (control == null)
                return;

            _control = control;
            _property = property;

            _to = targetValue;
            _from = _control.GetValue(_property);

            _currentTick = 0;
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _currentTick++;
            
            if (_currentTick > _totalTicks)
            {
                _timer.Stop();
                return;
            }

            var percentage = (float)_currentTick / _totalTicks;
            var easingPercentage = _easing.Ease(percentage);
            var finalValue = _from + _to * easingPercentage;

            _control.SetValue(_property, finalValue);
        }

        public void Dispose()
        {

        }
    }
}
