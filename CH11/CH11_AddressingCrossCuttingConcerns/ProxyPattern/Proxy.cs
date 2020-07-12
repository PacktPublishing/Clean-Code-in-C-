using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Custom.Messages;
using System;

namespace CH11_AddressingCrossCuttingConcerns.ProxyPattern
{
    public class Proxy : IService
    {
        private static readonly LogSource logSource = LogSource.Get();
        private readonly IService _service;

        public Proxy(IService service)
        {
            _service = service;
        }

        public void Request()
        {
            Console.WriteLine("Proxy: Request();");
            _service.Request();
        }
    }
}
