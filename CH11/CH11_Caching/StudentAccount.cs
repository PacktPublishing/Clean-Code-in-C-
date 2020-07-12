using PostSharp.Patterns.Caching.Dependencies;
using System;

namespace CH11_Caching
{
    [Serializable]
    internal class StudentAccount : ICacheDependency
    {
        public int StudentAccountId;

        public string GetCacheKey()
        {
            return $"Account:{StudentAccountId}";
        }
    }
}
