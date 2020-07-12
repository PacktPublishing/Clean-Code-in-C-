using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11_AddressingCrossCuttingConcerns.ProxyPattern
{
    public class Service : IService
    {
        public void Request()
        {
            Console.WriteLine("Service: Request();");
        }
    }
}
