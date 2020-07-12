using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.Builder
{
    public class Director
    {
        public void Build(Builder builder)
        {
            builder.BuildSection1();
            builder.BuildSection2();
        }
    }
}
