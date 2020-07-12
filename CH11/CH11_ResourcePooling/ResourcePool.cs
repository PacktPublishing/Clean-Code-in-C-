using System;
using System.Collections.Concurrent;

namespace CH11_ResourcePooling
{
    public class ResourcePool<T>
    {
        private readonly ConcurrentBag<T> _resources;
        private readonly Func<T> _resourceGenerator;

        public ResourcePool(Func<T> resourceGenerator)
        {
            _resourceGenerator = resourceGenerator ??
                throw new ArgumentNullException(nameof(resourceGenerator));
            _resources = new ConcurrentBag<T>();
        }

        public T Get() => _resources.TryTake(out T item) ? item : _resourceGenerator();
        public void Return(T item) => _resources.Add(item);
    }
}
