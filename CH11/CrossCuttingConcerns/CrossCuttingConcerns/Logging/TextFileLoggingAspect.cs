using PostSharp.Aspects;
using PostSharp.Serialization;
using CrossCuttingConcerns.FileSystem;

namespace CrossCuttingConcerns.Logging
{
    [PSerializable]
    public class TextFileLoggingAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            LogFile.AppendTextToFile("Log.txt", $"\nMethod: {args.Method.Name}, OnEntry().");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            LogFile.AppendTextToFile("Log.txt", $"\nMethod: {args.Method.Name}, OnSuccess().");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            LogFile.AppendTextToFile("Log.txt", $"\nMethod: {args.Method.Name}, OnExit().");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            LogFile.AppendTextToFile("Exception.log", $"\nAn exception was thrown in {args.Method.Name}. {args}");
        }
    }
}