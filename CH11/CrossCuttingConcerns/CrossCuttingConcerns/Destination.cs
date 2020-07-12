using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuttingConcerns
{
    [Flags]
    public enum Destination
    {
        String,
        Console,
        File
    }
}
