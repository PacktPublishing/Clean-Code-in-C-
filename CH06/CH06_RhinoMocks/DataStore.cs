using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH06_RhinoMocks
{
    public class DataStore<T>
    {
        public DataStore() { }
        public DataStore(T item) {}
        private T _item;
        public virtual T Item { get; set; }
    }
}
