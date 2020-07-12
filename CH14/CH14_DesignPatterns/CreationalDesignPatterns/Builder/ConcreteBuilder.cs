using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.Builder
{
    public class ConcreteBuilder : Builder
    {
        private Product _product;

        public ConcreteBuilder()
        {
            _product = new Product();
        }

        public override void BuildSection1()
        {
            _product.Add("Section 1");
        }

        public override void BuildSection2()
        {
            _product.Add(("Section 2"));
        }

        public override Product GetProduct()
        {
            return _product;
        }
    }
}
