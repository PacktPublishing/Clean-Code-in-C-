using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuttingConcerns
{
    public interface IBusinessObject<T> where T : class
    {
        void Add(dynamic data);
        void Edit(dynamic data);
        void Delete(dynamic data);
        dynamic Read(dynamic data);
    }
}
