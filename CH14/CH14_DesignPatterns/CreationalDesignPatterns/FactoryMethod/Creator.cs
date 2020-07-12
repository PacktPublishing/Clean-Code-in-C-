using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.FactoryMethod
{
    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }
}
