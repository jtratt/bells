using Bells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrintPlainBob
{
    class PrintLineStriker : IStrikeable
    {
        public int NumberOfBells { get; set; } = 8;

        private int strikeCount = 0;

        public void Strike(int bellNumber)
        {
            Console.Write(bellNumber);
            strikeCount++;

            if (strikeCount == NumberOfBells)
            {
                Console.WriteLine();
                strikeCount = 0;
            }
        }
    }
}
