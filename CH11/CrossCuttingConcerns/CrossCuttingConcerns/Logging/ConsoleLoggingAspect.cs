using PostSharp.Aspects;
using PostSharp.Serialization;
using System;

namespace CrossCuttingConcerns.Logging
{
    [PSerializable]
    public class ConsoleLoggingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine($"Method: {args.Method.Name}, OnEntry().");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine($"Method: {args.Method.Name}, OnExit().");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine($"Method: {args.Method.Name}, OnSuccess().");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine($"An exception was thrown in {args.Method.Name}. {args}");
        }
    }
}