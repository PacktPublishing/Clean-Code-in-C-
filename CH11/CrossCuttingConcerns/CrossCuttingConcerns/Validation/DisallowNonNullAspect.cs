using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace CrossCuttingConcerns.Validation
{
    [PSerializable]
    public class DisallowNonNullAspect : OnMethodBoundaryAspect
    {
        private int[] _inputArgumentsToValidate;
        private int[] _outputArgumentsToValidate;
        private string[] _parameterNames;
        private bool _validateReturnValue;
        private string _memberName;
        private bool _isProperty;

        public DisallowNonNullAspect() : this(ValidationFlags.AllPublic)
        {
        }

        public DisallowNonNullAspect(ValidationFlags validationFlags)
        {
            ValidationFlags = validationFlags;
        }

        public ValidationFlags ValidationFlags { get; set; }


        public override bool CompileTimeValidate(MethodBase method)
        {
            var methodInformation = MethodInformation.GetMethodInformation(method);
            var parameters = method.GetParameters();

            if (!ValidationFlags.HasFlag(ValidationFlags.NonPublic) && !methodInformation.IsPublic) return false;
            if (!ValidationFlags.HasFlag(ValidationFlags.Properties) && methodInformation.IsProperty) return false;
            if (!ValidationFlags.HasFlag(ValidationFlags.Methods) && !methodInformation.IsProperty) return false;

            _parameterNames = parameters.Select(p => p.Name).ToArray();
            _memberName = methodInformation.Name;
            _isProperty = methodInformation.IsProperty;

            var argumentsToValidate = parameters.Where(p => p.MayNotBeNull()).ToArray();

            _inputArgumentsToValidate = ValidationFlags.HasFlag(ValidationFlags.Arguments) ? argumentsToValidate.Where(p => !p.IsOut).Select(p => p.Position).ToArray() : new int[0];

            _outputArgumentsToValidate = ValidationFlags.HasFlag(ValidationFlags.OutValues) ? argumentsToValidate.Where(p => p.ParameterType.IsByRef).Select(p => p.Position).ToArray() : new int[0];

            if (!methodInformation.IsConstructor)
            {
                _validateReturnValue = ValidationFlags.HasFlag(ValidationFlags.ReturnValues) &&
                                            methodInformation.ReturnParameter.MayNotBeNull();
            }

            var validationRequired = _validateReturnValue || _inputArgumentsToValidate.Length > 0 || _outputArgumentsToValidate.Length > 0;

            return validationRequired;
        }


        public override void OnEntry(MethodExecutionArgs args)
        {
            foreach (var argumentPosition in _inputArgumentsToValidate)
            {
                if (args.Arguments[argumentPosition] != null) continue;
                var parameterName = _parameterNames[argumentPosition];

                if (_isProperty)
                {

                    throw new ArgumentNullException(parameterName, $"Cannot set the value of property '{_memberName}' to null.");
                }
                else
                {
                    throw new ArgumentNullException(parameterName);
                }
            }
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            foreach (var argumentPosition in _outputArgumentsToValidate)
            {
                if (args.Arguments[argumentPosition] != null) continue;
                var parameterName = _parameterNames[argumentPosition];
                throw new InvalidOperationException($"Out parameter '{parameterName}' is null.");
            }

            if (!_validateReturnValue || args.ReturnValue != null) return;

            if (_isProperty)
            {
                throw new InvalidOperationException($"Return value of property '{_memberName}' is null.");
            }

            throw new InvalidOperationException($"Return value of method '{_memberName}' is null.");
        }

        private class MethodInformation
        {
            private static MethodInformation CreateInstance(MethodInfo method)
            {
                return new MethodInformation(method);
            }

            private MethodInformation(ConstructorInfo constructor) : this((MethodBase)constructor)
            {
                IsConstructor = true;
                Name = constructor.Name;

            }

            private MethodInformation(MethodInfo method) : this((MethodBase)method)
            {
                IsConstructor = false;
                Name = method.Name;
                if (method.IsSpecialName &&
                    (Name.StartsWith("set_", StringComparison.Ordinal) ||
                        Name.StartsWith("get_", StringComparison.Ordinal)))
                {
                    Name = Name.Substring(4);
                    IsProperty = true;
                }
                ReturnParameter = method.ReturnParameter;
            }

            private MethodInformation(MethodBase method)
            {
                IsPublic = method.IsPublic;

            }

            public static MethodInformation GetMethodInformation(MethodBase methodBase)
            {
                var ctor = methodBase as ConstructorInfo;
                if (ctor != null) return new MethodInformation(ctor);
                var method = methodBase as MethodInfo;
                return method == null ? null : CreateInstance(method);
            }

            public string Name { get; private set; }

            public bool IsProperty { get; private set; }

            public bool IsPublic { get; private set; }

            public bool IsConstructor { get; private set; }


            public ParameterInfo ReturnParameter { get; private set; }
        }
    }
}