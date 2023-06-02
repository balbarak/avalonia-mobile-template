using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTemplate.Controls
{
    public class Rotator : Panel
    {
        private DispatcherTimer _timer;
        private TimeSpan _frameRate;
        private double _rotateDegree;
        private TimeSpan _prev;

        public static readonly StyledProperty<double> SpeedProperty =
            AvaloniaProperty.Register<Rotator, double>(nameof(Speed), defaultValue: .6);

        public double Speed { get => GetValue(SpeedProperty); set => SetValue(SpeedProperty, value); }

        public Rotator()
        {
            _frameRate = TimeSpan.FromSeconds(1 / 60.0);

            _timer = new DispatcherTimer()
            {
                Interval = _frameRate
            };

            _timer.Tick += OnTimerTick;

            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _rotateDegree += Speed * _frameRate.TotalMilliseconds;

            while (_rotateDegree > 360)
                _rotateDegree -= 360;

            RenderTransform = new RotateTransform(_rotateDegree);


            Debug.WriteLine("Speed: " + Speed);
            Debug.WriteLine("Rotate Degree: " + _rotateDegree);
        }
    }
}
