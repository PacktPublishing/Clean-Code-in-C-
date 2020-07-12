using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.RefactoredCode
{
    public class StaffShiftPatternReport : IReportFactory
    {
        public void Run()
        {
            Console.WriteLine("Running Staff Shift Pattern Report.");
        }
    }
}
