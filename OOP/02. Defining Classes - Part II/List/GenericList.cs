namespace List
{
    using System;
    using System.Linq;
    using System.Text;

    public class GenericList<T> where T : IComparable
    {
        private const int DefaultCapacity = 1;

        private T[] array;
        private int count = 0;
        private int capacity = DefaultCapacity;

        public GenericList() : this(DefaultCapacity) { }

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.array = new T[capacity];
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                if (index >= this.count)
                {
                    throw new IndexOutOfRangeException("This index is invalid!");
                }

                return this.array[index];
            }
        }

        // Resize the array if it is full
        private void Resize(int count)
        {
            // Decrease the lenght of the array
            if (count > this.array.Length - 1)
            {
                var newArray = new T[this.capacity * 2];
                Array.Copy(this.array, newArray, count);
                this.capacity *= 2;
                this.array = newArray;
            }

            // Increase the lenght of the array
            if (count < this.array.Length / 2)
            {
                var newArray = new T[this.capacity / 2];
                Array.Copy(this.array, newArray, this.count);
                this.capacity /= 2;
                this.array = newArray;
            }
        }

        /// <summary>
        /// Adds an element in the array.
        /// </summary>
        /// <param name="value">The value of the element.</param>
        public void Add(T value)
        {
            Resize(this.count);
            this.array[this.count] = value;
            this.count++;
        }

        /// <summary>
        /// Removes an element from the array by some index.
        /// </summary>
        /// <param name="index">The index of the element.</param>
        public void Remove(int index)
        {
            if (index >= this.count)
            {
                throw new IndexOutOfRangeException("This index is invalid!");
            }

            Array.Copy(this.array, index + 1, this.array, index, this.array.Length - index - 1);
            this.count--;
            Resize(this.count);
        }

        /// <summary>
        /// Inserts an element at given position in the array.
        /// </summary>
        /// <param name="index">The index of the position.</param>
        /// <param name="value">The value of the element.</param>
        public void Insert(int index, T value)
        {
            if (index >= this.count)
            {
                throw new IndexOutOfRangeException("This index is invalid!");
            }

            if (this.count == this.array.Length)
            {
                var newArray = new T[this.capacity * 2];
                Array.Copy(this.array, newArray, this.count);
                this.capacity *= 2;
                this.array = newArray;
            }

            Array.Copy(this.array, index, this.array, index + 1, this.array.Length - index - 1);
            this.array[index] = value;
            this.count++;
            Resize(this.count);
        }

        /// <summary>
        /// Clears the list and all information about it.
        /// </summary>
        public void Clear()
        {
            this.array = new T[DefaultCapacity];
            this.capacity = DefaultCapacity;
            this.count = 0;
        }

        /// <summary>
        /// Finds some element by its value.
        /// </summary>
        /// <param name="value">The value of the element.</param>
        /// <returns>Returns the index of the found element.</returns>
        public int IndexOf(T value)
        {
            return Array.IndexOf(this.array, value);
        }

        /// <summary>
        /// Counts the current length of the array.
        /// </summary>
        /// <returns>Returns the current length of the array.</returns>
        public int Count()
        {
            return this.count;
        }

        /// <summary>
        /// Counts the allocated length of the array.
        /// </summary>
        /// <returns>Returns the allocated length of the array.</returns>
        public int Length()
        {
            return this.array.Length;
        }

        // Finds the minimal element in the array
        public T Min<T>()
        {
            return (dynamic)this.array.Min();
        }

        // Finds the maximal element in the array
        public T Max<T>()
        {
            return (dynamic)this.array.Max();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("{");
            for (int element = 0; element < this.count; element++)
            {
                result.Append(this.array[element] + (element != this.count - 1 ? ", " : "}"));
            }

            return result.ToString();
        }
    }
}