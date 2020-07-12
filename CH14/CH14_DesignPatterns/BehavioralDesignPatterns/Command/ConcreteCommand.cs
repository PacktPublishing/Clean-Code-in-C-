using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.BehavioralDesignPatterns.Command
{
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver) { }

        public override void Execute()
        {
            Receiver.Action();
        }
    }
}
