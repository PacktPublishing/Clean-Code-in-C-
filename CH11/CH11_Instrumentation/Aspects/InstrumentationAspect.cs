using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Diagnostics;
using CH11_Instrumentation.FileSystem;
using System.IO;
using System.Reflection;

namespace CH11_Instrumentation.Aspects
{
    [PSerializable]
    [AttributeUsage(AttributeTargets.Method)]
    public class InstrumentationAspect : OnMethodBoundaryAspect
    {
        private static readonly string _location = Assembly.GetExecutingAssembly().Location.Replace(
            $"{Assembly.GetExecutingAssembly().GetName().Name}.exe", 
            ""
        );

        public override void OnEntry(MethodExecutionArgs args)
        {
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            new LogFile().AppendTextToFile(_location, "Profile.log", $"\nMethod: {args.Method.Name}, Start Time: {DateTime.Now}");
            args.MethodExecutionTag = Stopwatch.StartNew();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            new LogFile().AppendTextToFile(_location, "Exception.log", $"\n{DateTime.Now}: {args.Exception.Source} - {args.Exception.Message}");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var stopwatch = (Stopwatch)args.MethodExecutionTag;
            stopwatch.Stop();
            new LogFile().AppendTextToFile(_location, "Profile.log", $"\nMethod: {args.Method.Name}, Stop Time: {DateTime.Now}, Duration: {stopwatch.Elapsed}");
        }
    }
}
