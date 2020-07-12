using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CH14_DesignPatterns.StructuralDesignPatterns.Facade;
using CrossCuttingConcerns.Instrumentation;
using CrossCuttingConcerns.Logging;

namespace CH14_DesignPatterns.CreationalDesignPatterns.Builder
{
    public class StringConcatenation
    {
        private static DateTime _startTime;
        private static long _durationPlus;
        private static long _durationSb;

        public static void UsingThePlusOperator()
        {
            _startTime = DateTime.Now;
            var text = string.Empty;
            for (var x = 1; x <= 10000; x++)
            {
                text += $"Line: {x}, I must not be a lazy programmer, and should continually develop myself!\n";
            }
            _durationPlus = (DateTime.Now - _startTime).Ticks;
            Console.WriteLine($"Duration (Ticks) Using Plus Operator: {_durationPlus}");
        }

        public static void UsingTheStringBuilder()
        {
            _startTime = DateTime.Now;
            var sb = new StringBuilder();
            for (var x = 1; x <= 1000000; x++)
            {
                sb.AppendLine($"Line: {x}, I must not be a lazy programmer, and should continually develop myself!");
            }
            _durationSb = (DateTime.Now - _startTime).Ticks;
            Console.WriteLine($"Duration (Ticks) Using StringBuilder: {_durationSb}");
        }

        public static void PrintTimeDifference()
        {
            var difference = _durationPlus - _durationSb;
            Console.WriteLine($"That's a time difference of {difference} ticks.");
            Console.WriteLine($"{difference} ticks = {TimeSpan.FromTicks(difference).TotalSeconds} seconds.");
        }
    }
}
