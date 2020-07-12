using Amazon.Runtime.Internal.Util;
using System;

namespace CH10_Concurrency.Attributes
{
    internal class StaticMemoryCache : ICache
    {
        private TimeSpan timeSpan;

        public StaticMemoryCache(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        public TimeSpan MaximumItemLifespan { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeSpan CacheClearPeriod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ItemCount => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}