using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Amazon.Runtime.Internal.Util;

namespace CH10_Concurrency.Attributes
{
    [Serializable]
    public class CacheAttribute : MethodInterceptionAspect
    {
        [NonSerialized] private object syncRoot;
        [NonSerialized]
        private static readonly ICache _cache;
        private string _methodName;

        static CacheAttribute()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                // one minute cache
                _cache = new StaticMemoryCache(new TimeSpan(0, 1, 0));
                // use an IoC container/service locator here in practice
            }
        }

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            _methodName = method.Name;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            syncRoot = new object();
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var key = BuildCacheKey(args.Arguments);
            if (_cache[key] != null)
            {
                args.ReturnValue = _cache[key];
            }
            else
            {
                lock (syncRoot)
                {
                    if (_cache[key] == null)
                    {
                        var returnVal = args.Invoke(args.Arguments);
                        args.ReturnValue = returnVal;
                        _cache[key] = returnVal;
                    }
                    else
                    {
                        args.ReturnValue = _cache[key];
                    }
                }
            }
        }

        private string BuildCacheKey(Arguments arguments)
        {
            var sb = new StringBuilder();
            sb.Append(_methodName);
            foreach (var argument in arguments.ToArray())
            {
                sb.Append(argument == null ? "_" : argument.ToString());
            }
            return sb.ToString();
        }

        public override bool CompileTimeValidate(MethodBase method)
        {
            var methodInfo = method as MethodInfo;
            if (methodInfo != null)
            {
                var returnType = methodInfo.ReturnType;
                if (IsDisallowedCacheReturnType(returnType))
                {
                    Message.Write(SeverityType.Error, "998",
                      "Methods with return type {0} cannot be cached in {1}.{2}",
                      returnType.Name, _className, _methodName);
                    return false;
                }
            }
            return true;
        }

        private static readonly IList DisallowedTypes = new List
                          {
                                  typeof (Stream),
                                  typeof (IEnumerable),
                                  typeof (IQueryable)
                          };
        private static bool IsDisallowedCacheReturnType(Type returnType)
        {
            return DisallowedTypes.Any(t => t.IsAssignableFrom(returnType));
        }
    }
}
