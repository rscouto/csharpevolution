using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CsharpEvolution.Tests01.SimpleCalculator.Common
{
    public class Timer : IDisposable
    {
        private readonly Stopwatch _stopWatch;
        private readonly string _method;

        public Timer(string method)
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
            _method = method;
        }
        public void Dispose()
        {
            _stopWatch.Stop();
            TimeSpan timeTaken = _stopWatch.Elapsed;
            string elapsed = $"\n {_method} levou {timeTaken.Milliseconds}ms \n";
            Console.WriteLine(elapsed);
        }
    }

    public static class LogExtension
    {
        public static IDisposable MeasureTimeCurrentMethod<T>(
            this T _,
            [CallerMemberName] string callerMethodName = "")
        {
            return new Timer($"{typeof(T).Name}.{callerMethodName}");
        }
    }
}
