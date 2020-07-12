using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Diagnostics.Audit;
using TestHarness.Models;

namespace TestHarness
{
    public class PurchaseOrder : BusinessObject
    {

        [Audit]
        public void Approve(string _ = null)
        {
        }
    }
}
