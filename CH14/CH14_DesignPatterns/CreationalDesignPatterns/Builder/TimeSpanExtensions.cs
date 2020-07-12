using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.Builder
{
    public static class TimeSpanExtensions
    {
        private enum TimeSpanElement
        {
            Millisecond,
            Second,
            Minute,
            Hour,
            Day
        }

        public static string ToFriendlyDisplay(this TimeSpan timeSpan, int maxNrOfElements)
        {
            maxNrOfElements = Math.Max(Math.Min(maxNrOfElements, 5), 1);
            var parts = new[]
                {
                    Tuple.Create(TimeSpanElement.Day, timeSpan.Days),
                    Tuple.Create(TimeSpanElement.Hour, timeSpan.Hours),
                    Tuple.Create(TimeSpanElement.Minute, timeSpan.Minutes),
                    Tuple.Create(TimeSpanElement.Second, timeSpan.Seconds),
                    Tuple.Create(TimeSpanElement.Millisecond, timeSpan.Milliseconds)
                }
                .SkipWhile(i => i.Item2 <= 0)
                .Take(maxNrOfElements);

            return string.Join(", ", parts.Select(p => string.Format("{0} {1}{2}", p.Item2, p.Item1, p.Item2 > 1 ? "s" : string.Empty)));
        }
    }
}
