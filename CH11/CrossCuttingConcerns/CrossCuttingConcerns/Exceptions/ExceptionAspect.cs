using System;
using System.Diagnostics;
using System.IO;
using CrossCuttingConcerns.FileSystem;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace CrossCuttingConcerns.Exceptions
{
    [PSerializable]
    public class ExceptionAspect : OnExceptionAspect
    {
        private bool _consoleOutput;

        public ExceptionAspect(bool consoleOutput)
        {
            _consoleOutput = consoleOutput;
        }

        public string Message { get; set; }

        public Type ExceptionType { get; set; }

        public FlowBehavior Behavior { get; set; }

        public override void OnException(MethodExecutionArgs args)
        {
            var message = args.Exception != null ? args.Exception.Message : "Unknown error occured.";
            var msg = $"\n{DateTime.Now}: Method: {args.Method}, Exception: {message}";
            if (_consoleOutput)
                Console.WriteLine(msg);
            LogFile.AppendTextToFile("Exceptions.log", msg);
            args.FlowBehavior = FlowBehavior.Continue;
        }

        public override Type GetExceptionType(System.Reflection.MethodBase targetMethod)
        {
            return ExceptionType;
        }
    }
}
