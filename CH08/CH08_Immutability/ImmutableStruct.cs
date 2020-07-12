using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH08_Immutability
{
    internal struct ImmutableStruct
    {
        private ImmutableArray<int> _immutableArray;

        public ImmutableStruct(ImmutableArray<int> immutableArray)
        {
            _immutableArray = immutableArray;
        }

        public int[] GetIntArray()
        {
            return _immutableArray.ToArray<int>();
        }
    }
}
