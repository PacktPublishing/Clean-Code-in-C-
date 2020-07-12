using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.IO;

namespace CH11_AddressingCrossCuttingConcerns.Attributes
{
    [PSerializable]
    public class ExceptionAttribute : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine($"Oops! {args.Exception.Message}");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var directory = Directory.GetCurrentDirectory();
            var file = "Errors.log";
            using (StreamWriter sw = File.AppendText(Path.Combine(directory, file)))
            {
                var message = args.Exception != null ? args.Exception.Message : "Unknown error occured.";
                sw.WriteLine($"{DateTime.Now}: Method: {args.Method}, Exception: {message}");
                sw.Flush();
            }
        }
    }
}
