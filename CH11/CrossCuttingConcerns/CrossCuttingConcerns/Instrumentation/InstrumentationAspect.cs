using System;
using System.Diagnostics;
using CrossCuttingConcerns.FileSystem;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace CrossCuttingConcerns.Instrumentation
{
    [PSerializable]
    [AttributeUsage(AttributeTargets.Method)]
    public class InstrumentationAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            LogFile.AppendTextToFile("Profile.log", $"\nMethod: {args.Method.Name}, Start Time: {DateTime.Now}");
            args.MethodExecutionTag = Stopwatch.StartNew();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            LogFile.AppendTextToFile("Exception.log", $"\n{DateTime.Now}: {args.Exception.Source} - {args.Exception.Message}");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var stopwatch = (Stopwatch)args.MethodExecutionTag;
            stopwatch.Stop();
            LogFile.AppendTextToFile("Profile.log", $"\nMethod: {args.Method.Name}, Stop Time: {DateTime.Now}, Duration: {stopwatch.Elapsed}");
        }
    }
}