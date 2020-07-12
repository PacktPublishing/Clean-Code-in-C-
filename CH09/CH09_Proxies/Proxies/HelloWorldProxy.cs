using CH09_Proxies.Apis;
using CH09_Proxies.Interfaces;
using System;

namespace CH09_Proxies.Proxies
{
    public class HelloWorldProxy : HelloWorldInterface
    {
        public string GetMessage()
        {
            return new HelloWorldApi().GetMessage();
        }
    }
}
