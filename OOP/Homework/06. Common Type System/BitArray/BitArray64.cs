using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BitArray
{
    class BitArray64 : IEnumerable<int>
    {
        // Property
        public ulong Number { get; private set; }

        // Constructor
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        // Indexator
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63) throw new IndexOutOfRangeException();
                return (this.Number & ((ulong)1 << index)) == 0 ? 0 : 1;
            }
            set
            {
                if (index < 0 || index > 63) throw new IndexOutOfRangeException();
                if (value != 0 && value != 1) throw new ArgumentOutOfRangeException();

                this.Number = (this.Number & ~((ulong)1 << index) | ((ulong)value << index));
            }
        }

        // Returns an enumerator that iterates through a collection
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        // Method Equals
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return this.Number.Equals((obj as BitArray64).Number);
        }

        // Boolean operator ==
        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        // Boolean operator !=
        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        // Method GetHashCode
        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        // Override to string method
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < 64; i += 4)
            {
                str.AppendFormat(
                    "[{0}]={1} \t[{2}]={3} \t[{4}]={5} \t[{6}]={7}\n",
                    i, this[i], i + 1, this[i + 1], i + 2, this[i + 2], i + 3, this[i + 3]);
            }
            return str.ToString();
        }
    }
}
