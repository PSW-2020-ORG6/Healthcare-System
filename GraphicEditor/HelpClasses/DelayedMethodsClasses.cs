using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace GraphicEditor.HelpClasses
{
    public static class ActionExtensions
    {
        public static void RunAfter(this Action action, TimeSpan span)
        {
            var dispatcherTimer = new DispatcherTimer { Interval = span };
            dispatcherTimer.Tick += (sender, args) =>
            {
                var timer = sender as DispatcherTimer;
                if (timer != null)
                {
                    timer.Stop();
                }

                action();
            };
            dispatcherTimer.Start();
        }
    }

    //<Namespace>.Utilities
    public static class CommonUtil
    {
        public static void Run(Action action, TimeSpan afterSpan)
        {
            action.RunAfter(afterSpan);
        }
    }
}
