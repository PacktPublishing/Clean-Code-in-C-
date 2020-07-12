using CH09_Proxies.Interfaces;

namespace CH09_Proxies.Apis
{
    internal class HelloWorldApi : HelloWorldInterface
    {
        public string GetMessage()
        {
            return "Hello World!";
        }
    }
}
