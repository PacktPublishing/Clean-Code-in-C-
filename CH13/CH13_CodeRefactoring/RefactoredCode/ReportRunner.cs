using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.RefactoredCode
{
    public class ReportRunner
    {
        public void RunReport(Report report)
        {
            var reportName = $"CH13_CodeRefactoring.RefactoredCode.{report}Report, CH13_CodeRefactoring";
            var type = Type.GetType(reportName);
            var factory = Activator.CreateInstance(Type.GetType(reportName) ?? throw new InvalidOperationException()) as IReportFactory;
            factory?.Run();
        }
    }
}
