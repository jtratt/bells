using Bells;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayPlainBobDemo
{
    public class PlainBob : IMethod
    {
        private Transform _LeadEndTransform;

        private Transform _EvenChangeTransform;

        private Transform _OddChangeTransform;

        public string Name { get; set; } = "Plain Bob";

        public int NumberOfBells { get; set; } = 8;

        public int CallInterval
        {
            get { return 2 * NumberOfBells; }
        }

        public int PlainCourseLength
        {
            get
            {
                return NumberOfBells * 2 * (NumberOfBells - 1);
            }
        }

        public PlainBob(int numberOfBells)
        {
            this.NumberOfBells = numberOfBells;
            this._LeadEndTransform = GetLeadEndTransform();
            this._EvenChangeTransform = GetEvenChangeTranform();
            this._OddChangeTransform = GetOddChangeTransform();
        }

        /// <summary>
        /// Gets the transform for an odd step in the method.
        /// </summary>
        /// <returns></returns>
        private Transform GetOddChangeTransform()
        {
            int[] transform = new int[NumberOfBells];
            transform[0] = 1;

            for (int i = 1; i < NumberOfBells - 1; i++)
            {
                transform[i] = i % 2 == 1
                    ? i + 2
                    : i;
            }

            transform[NumberOfBells - 1] = NumberOfBells;

            return new Transform(transform);
        }

        /// <summary>
        /// Gets the transform for an even step of the method.
        /// </summary>
        /// <returns></returns>
        private Transform GetEvenChangeTranform()
        {
            int[] transform = new int[NumberOfBells];
            for (int i = 0; i < NumberOfBells; i++)
            {
                transform[i] = GetEvenPairsSwapped(i);
            }
            return new Transform(transform);
        }

        /// <summary>
        /// Gets the transform for the lead end, where positions 1 and 2 are fixed but the rest swapped.
        /// </summary>
        private Transform GetLeadEndTransform()
        {
            int[] transform = new int[NumberOfBells];
            transform[0] = 1;
            transform[1] = 2;

            for (int i = 2; i < NumberOfBells; i++)
            {
                transform[i] = GetEvenPairsSwapped(i);
            }

            return new Transform(transform);
        }

        /// <summary>
        /// Gets the transform value for the ith position where each pair of bells has swapped,
        /// i.e the transform "21436587..." returns 2 for i = 0; 1 for i = 1... etc.
        /// </summary>
        /// <param name="i"></param>
        /// <returns>21436587...</returns>
        private int GetEvenPairsSwapped(int i)
        {
            return i % 2 == 0 
                ? i + 2 
                : i;
        }

        public Transform GetTransform(int changeCount)
        {
            var isLeadEnd = changeCount % (CallInterval) == 0;
            if (isLeadEnd)
            {
                return _LeadEndTransform;
            }
            else if (changeCount % 2 == 1)
            {
                return _EvenChangeTransform;
            }
            else
            {
                return _OddChangeTransform;
            }
        }
    }
}
