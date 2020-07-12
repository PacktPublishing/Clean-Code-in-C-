using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.BehavioralDesignPatterns.Command
{
    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver.Action() has been executed.");
        }
    }
}
