using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.RefactoredCode
{
    public class LooselyCoupled
    {
        private readonly IService _service;

        public LooselyCoupled(IService service)
        {
            _service = service;
        }

        public void DoWork()
        {
            _service.Operation();
        }
    }
}
