using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.ProblemCode
{
    public class CyclomaticComplexity
    {
        public void RunReport(Report report)
        {
            switch (report)
            {
                case Report.EndofMonthSalaryRun:
                    Console.WriteLine("Running End of Month Salary Run Report.");
                    break;
                case Report.EndofMonthSalesFigures:
                    Console.WriteLine("Running End of Month Sales Figures Report.");
                    break;
                case Report.HrLeavers:
                    Console.WriteLine("Running HR Leavers Report.");
                    break;
                case Report.HrStarters:
                    Console.WriteLine("Running HR Starters Report.");
                    break;
                case Report.StaffShiftPattern:
                    Console.WriteLine("Running Staff Shift Pattern Report.");
                    break;
                case Report.YearToDateSalesFigures:
                    Console.WriteLine("Running Year to Date Sales Figures Report.");
                    break;
                default:
                    Console.WriteLine("Report unrecognized.");
                    break;
            }
        }

        public string GetHrReport(string reportName)
        {
            if (reportName.Equals("Staff Joiners Report"))
                return "Staff Joiners Report";
            else if (reportName.Equals("Staff Leavers Report"))
                return "Staff Leavers Report";
            else if (reportName.Equals("Balance Sheet Report"))
                return "Balance Sheet Report";
            else
                return "";
        }
    }
}
