using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.RefactoredCode
{
    public class LeaversReport : ReportBase
    {
        public override void Print()
        {
            Console.WriteLine("Printing Leavers Report.");
        }
    }
}
