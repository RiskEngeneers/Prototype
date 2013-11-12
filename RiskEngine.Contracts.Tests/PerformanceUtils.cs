using System;
using System.Diagnostics;

namespace RiskEngine.Contracts.Tests
{
    public static class PerformanceUtils
    {
        public static TimeSpan Measure(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static TimeSpan MeasureIterations(Action action, int iterations)
        {
            action();
            return Measure(() =>
            {
                for (var i = 0; i < iterations; i++)
                {
                    action();
                }
            });
        }
    }
}
