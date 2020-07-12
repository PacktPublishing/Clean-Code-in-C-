using CH11_AddressingCrossCuttingConcerns.Attributes;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using System.Reflection;

namespace CH11_AddressingCrossCuttingConcerns.Aspects
{
    [PSerializable]
    [LinesOfCodeAvoided(2)]
    public sealed class FilterMethodArgumentsAspect : MethodInterceptionAspect
    {
        private FilterAttribute[] _filters;

        internal FilterMethodArgumentsAspect(MethodBase method)
        {
            _filters = new FilterAttribute[method.GetParameters().Length];
        }


        internal void SetFilter(ParameterInfo parameter, FilterAttribute filter)
        {
            if (_filters[parameter.Position] != null)
            {
                // If you want to support more than 1 filter, you will need a more complex data structure and to cope with priorities.
                Message.Write(parameter, SeverityType.Error, "MY01", "There cannot be more than 1 filter on parameter {0}.",
                  parameter);
                return;
            }

            _filters[parameter.Position] = filter;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            for (var i = 0; i < _filters.Length; i++)
            {
                var filter = _filters[i];
                if (filter != null)
                {
                    args.Arguments[i] = filter.ApplyFilter(args.Arguments[i]);
                }
            }

            args.Proceed();
        }
    }
}