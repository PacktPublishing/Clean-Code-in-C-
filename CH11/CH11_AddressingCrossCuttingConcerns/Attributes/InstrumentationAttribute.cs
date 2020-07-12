using PostSharp.Aspects;
using PostSharp.Serialization;

namespace CH11_AddressingCrossCuttingConcerns.Attributes
{
    // Stopwatch example for method execution time and log result to file..
    [PSerializable]
    public class InstrumentationAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
        }
    }
}
