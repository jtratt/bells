using System;

namespace Bells
{
    /// <summary>
    /// Represents a permutation of N bells.
    /// </summary>
    public class Change : IEquatable<Change>
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

        public Change(int size)
        {
            this._Order = new int[size];
            for (int i = 0; i < size; i++)
            {
                this._Order[i] = i + 1;
            }
        }

        public Change(int[] change)
        {
            this._Order = new int[change.Length];
            change.CopyTo(this._Order, 0);
        }

        public bool Equals(Change other)
        {
            return
                this.Count == other.Count &&
                ContentsMatch(this, other);
        }

        private bool ContentsMatch(Change order1, Change order2)
        {
            for (int i = 0; i < order1.Count; i++)
            {
                if (order1[i] != order2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void ApplyTransform(Transform transform)
        {
            if (this.Count < transform.Count)
            {
                throw new InvalidOperationException("A transform cannot be applied to a change smaller than it.");
            }

            int[] change = new int[this.Count];
            for (int i = 0; i < transform.Count; i++)
            {
                change[i] = this[transform[i] - 1];
            }

            this._Order = change;
        }
    }
}
