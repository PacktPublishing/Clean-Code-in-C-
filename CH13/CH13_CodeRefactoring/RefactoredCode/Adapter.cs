using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.RefactoredCode
{
    public class Adapter : Target
    {
        // ReSharper disable once IdentifierTypo
        private readonly Adaptee _adaptee = new Adaptee();

        public override void Operation()
        {
            _adaptee.AdapteeOperation();
        }
    }
}
