using System;
using System.Collections.Generic;
using System.Text;

namespace Bells
{
    public interface IMethod
    {
        string Name { get; set; }

        int NumberOfBells { get; set; }

        int CallInterval { get; }

        int PlainCourseLength { get; }

        Transform GetTransform(int changeCount);
    }
}
