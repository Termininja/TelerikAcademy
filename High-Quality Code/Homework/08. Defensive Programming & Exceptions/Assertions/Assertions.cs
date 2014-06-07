namespace Assertions
{
    using System;
    using System.Linq;
    using System.Diagnostics;

    class Assertions
    {
        /// <summary>
        /// Sorts some array of elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements in array.</typeparam>
        /// <param name="arr">The array of elements.</param>
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array cannot be null!");
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        /// <summary>
        /// Find the index of the minimal element in an array.
        /// </summary>
        /// <typeparam name="T">The type of the elments in array.</typeparam>
        /// <param name="arr">The array.</param>
        /// <param name="startIndex">The start index of the search.</param>
        /// <param name="endIndex">The end index of the search.</param>
        /// <returns>Returns the index of the minamal element.</returns>
        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array can not be null!");
            Debug.Assert(startIndex >= 0, "Start index is not positive!");
            Debug.Assert(endIndex >= 0, "End index is not positive!");
            Debug.Assert(startIndex <= endIndex, "Start index is not before end index!");
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        /// <summary>
        /// Swaps the values of two elements.
        /// </summary>
        /// <typeparam name="T">The type of the both values.</typeparam>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        /// <summary>
        /// Search for the index of some element value in an array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="arr">The array.</param>
        /// <param name="value">The searched value.</param>
        /// <returns>Returns the index of the element if exist or -1.</returns>
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array can not be null!");

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        /// <summary>
        /// Search for the index of some value from range of elements in an array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="arr">The array.</param>
        /// <param name="value">The searched value.</param>
        /// <param name="startIndex">The start index of the range of elements.</param>
        /// <param name="endIndex">The end index of the range of elements.</param>
        /// <returns>Returns the index of the element if exist or -1.</returns>
        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array can not be null!");
            Debug.Assert(startIndex >= 0, "Start index is not positive!");
            Debug.Assert(endIndex >= 0, "End index is not positive!");
            Debug.Assert(startIndex <= endIndex, "Start index is not before end index!");
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}