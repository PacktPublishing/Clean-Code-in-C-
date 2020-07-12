using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.BehavioralDesignPatterns.Command
{
    public abstract class Command
    {
        protected Receiver Receiver;

        public Command(Receiver receiver)
        {
            Receiver = receiver;
        }

        public abstract void Execute();
    }
}
