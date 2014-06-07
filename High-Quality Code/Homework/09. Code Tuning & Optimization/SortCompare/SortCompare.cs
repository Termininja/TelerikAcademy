namespace SortCompare
{
    using System;

    class SortCompare
    {
        /// <summary>
        /// Insertion sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of array.</typeparam>
        /// <param name="array">The array.</param>
        public static void Insertion<T>(T[] array) where T : IComparable<T>
        {
            for (float k = 0; k < 100000; k++)
            {
                int i, j;
                for (i = 1; i < array.Length; i++)
                {
                    T value = array[i];
                    j = i - 1;
                    while ((j >= 0) && (array[j].CompareTo(value) > 0))
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = (T)value;
                }
            }
        }

        /// <summary>
        /// Selection sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of array.</typeparam>
        /// <param name="array">The array.</param>
        public static void Selection<T>(T[] array) where T : IComparable<T>
        {
            for (float k = 0; k < 100000; k++)
            {
                for (int sortedSize = 0; sortedSize < array.Length; sortedSize++)
                {
                    int minElementIndex = sortedSize;
                    T minElementValue = array[sortedSize];
                    for (int i = sortedSize + 1; i < array.Length; i++)
                    {
                        if (array[i].CompareTo(minElementValue) < 0)
                        {
                            minElementIndex = i;
                            minElementValue = array[i];
                        }
                    }
                    array[minElementIndex] = array[sortedSize];
                    array[sortedSize] = minElementValue;
                }
            }
        }

        /// <summary>
        /// Quicksort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of array.</typeparam>
        /// <param name="array">The array.</param>
        public static void Quicksort<T>(T[] array) where T : IComparable<T>
        {
            for (float k = 0; k < 100000; k++)
            {
                QuickSort(array, 0, array.Length - 1);
            }
        }

        static void QuickSort<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable<T>
        {
            if (leftIndex >= rightIndex) return;
            int middle = Partition(array, leftIndex, rightIndex);
            QuickSort(array, leftIndex, middle - 1);
            QuickSort(array, middle + 1, rightIndex);
        }

        static int Partition<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable<T>
        {
            Swap(ref array[leftIndex], ref array[rightIndex]);
            T pivot = array[rightIndex];
            int smallerIndex = leftIndex;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    Swap(ref array[smallerIndex++], ref array[i]);
                }
            }

            Swap(ref array[smallerIndex], ref array[rightIndex]);

            return smallerIndex;
        }

        static void Swap<T>(ref T firstElement, ref T secondElement)
        {
            T tempElement = firstElement;
            firstElement = secondElement;
            secondElement = tempElement;
        }
    }
}