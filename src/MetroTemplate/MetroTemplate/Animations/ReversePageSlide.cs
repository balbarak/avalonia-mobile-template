using Avalonia;
using Avalonia.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetroTemplate.Animations
{
    public class ReversePageSlide : PageSlide
    {

        public ReversePageSlide() : base()
        {
                
        }

        public ReversePageSlide(TimeSpan duration,SlideAxis slide = SlideAxis.Horizontal) : base(duration,slide)
        {
            
        }

        public override Task Start(Visual from, Visual to, bool forward, CancellationToken cancellationToken)
        {
            return base.Start(from, to, false, cancellationToken);
        }
    }
}
