using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.Builder
{
    public abstract class Builder
    {
        public abstract void BuildSection1();
        public abstract void BuildSection2();
        public abstract Product GetProduct();
    }
}
