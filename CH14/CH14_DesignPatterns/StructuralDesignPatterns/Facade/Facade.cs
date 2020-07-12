using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.StructuralDesignPatterns.Facade
{
    public class Facade
    {
        private SubsystemOne _subsystemOne = new SubsystemOne();
        private SubsystemTwo _subsystemTwo = new SubsystemTwo();

        public void SubsystemOneDoWork()
        {
            _subsystemOne.PrintName();
        }

        public void SubsystemTwoDoWork()
        {
            _subsystemTwo.PrintName();
        }
    }
}
