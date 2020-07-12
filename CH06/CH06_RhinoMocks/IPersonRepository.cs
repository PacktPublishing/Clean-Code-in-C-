using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH06_RhinoMocks
{
    public interface IPersonRepository
    {
        void GetPersonByName(string name);
    }
}
