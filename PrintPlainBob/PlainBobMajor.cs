using Bells;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintPlainBob
{
    public class PlainBobMajor : IMethod
    {
        public string Name { get; set; } = "Plain Bob";

        public int NumberOfBells { get; set; } = 8;

        public int CallInterval { get; } = 16;

        public int PlainCourseLength { get; } = 112;

        public Transform GetTransform(int changeCount)
        {
            var isLeadEnd = changeCount % (CallInterval) == 0;
            if (isLeadEnd)
            {
                return new Transform(1, 2, 4, 3, 6, 5, 8, 7);
            }
            else if (changeCount % 2 == 1)
            {
                return new Transform( 2, 1, 4, 3, 6, 5, 8, 7);
            }
            else
            {
                return new Transform(1, 3, 2, 5, 4, 7, 6, 8);
            }
        }
    }
}
