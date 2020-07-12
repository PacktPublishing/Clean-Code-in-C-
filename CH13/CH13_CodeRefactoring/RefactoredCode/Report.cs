using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.RefactoredCode
{
    [Flags]
    public enum Report
    {
        StaffShiftPattern,
        EndofMonthSalaryRun,
        HrStarters,
        HrLeavers,
        EndofMonthSalesFigures,
        YearToDateSalesFigures
    }
}
