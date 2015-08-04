namespace IEnumerableExtension
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Extension class for IEnumerable.
    /// </summary>
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Calculates the sum of the elements from some collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>Returns the sum of the elements.</returns>
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 0;
            collection.ToList().ForEach(element => sum += (dynamic)element);

            return sum;
        }

        /// <summary>
        /// Calculates the Product of the elements from some collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>Returns the product of the elements.</returns>
        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic product = 1;
            collection.ToList().ForEach(element => product *= (dynamic)element);

            return product;
        }

        /// <summary>
        /// Gets the minimal element from some collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>Returns the minimal element.</returns>
        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            return collection.OrderBy(element => element).First();
        }

        /// <summary>
        /// Gets the maximal element from some collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>Returns the maximal element.</returns>
        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            return collection.OrderBy(element => element).Last();
        }

        /// <summary>
        /// Gets the average value from some collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>Returns the average value.</returns>
        public static T Average<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            dynamic average = (dynamic)collection.Sum<T>() / collection.Count();

            return average;
        }
    }
}