using System;
using System.Collections.Generic;

namespace Bells
{
    public class Transform
    {
        private int[] _Order;


        public int this[int i]
        {
            get
            {
                return this._Order[i];
            }
        }

        public int Count
        {
            get
            {
                return this._Order.Length;
            }
        }

        public static Transform Identity(int numberOfBells)
        {
            int[] transform = new int[numberOfBells];
            for (int i = 0; i < numberOfBells; i++)
            {
                transform[i] = i + 1;
            }
            return new Transform(transform);
        }

        public Transform(IEnumerable<int> transform)
        {
            this._Order = (int[])transform;
        }

        public Transform(params int[] transform)
        {
            this._Order = transform;
        }

        /// <summary>
        /// TODO: produce a transform from place notation
        /// </summary>
        /// <param name="notationSnippet"></param>
        public Transform(string notationSnippet)
        {
            throw new NotImplementedException();
        }
    }
}