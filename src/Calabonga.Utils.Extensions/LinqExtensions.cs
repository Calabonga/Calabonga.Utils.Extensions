using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Calabonga.Utils.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>        
        /// Return specified number of random elements from collection        
        /// </summary>
        /// <param name="source">enumerable collection</param>
        /// <param name="count">number of random elements</param>
        [DebuggerStepThrough]
        public static IEnumerable<T> Randoms<T>(this IEnumerable<T> source, int count)
        {
            return source.OrderBy(a => Guid.NewGuid()).Take(count);
        }

        /// <summary>        
        /// Return single random element from collection
        /// </summary>
        /// <returns>
        /// Item or an Exception
        /// </returns>
        [DebuggerStepThrough]
        public static T Random<T>(this IEnumerable<T> source)
        {
            var enumerable = source as T[] ?? source.ToArray();
            var total = enumerable.Length;
            if (total > 0)
            {
                return enumerable.Randoms(1).First();
            }

            throw new InvalidOperationException("Requires more than one entry for a random selection");
        }

        /// <summary>       
        /// Return randomized collection     
        /// </summary>        
        [DebuggerStepThrough]
        public static IEnumerable<T> Randomized<T>(this IEnumerable<T> source)
        {
            var enumerable = source as T[] ?? source.ToArray();
            return enumerable.Randoms(enumerable.Length);
        }

        /// <summary>
        /// Determines whether the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The IEnumerable type.</typeparam>
        /// <param name="enumerable">The enumerable, which may be null or empty.</param>
        /// <returns>
        ///     <c>true</c> if the IEnumerable is null or empty; otherwise, <c>false</c>.
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable switch
            {
                null => true,
                ICollection<T> collection => collection.Count < 1,
                _ => enumerable.Any()
            };
        }

        /// <summary>
        /// Determines whether the collection is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">The ICollection type.</typeparam>
        /// <param name="collection">The collection, which may be null or empty.</param>
        /// <returns>
        ///     <c>true</c> if the ICollection is null or empty; otherwise, <c>false</c>.
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            if (collection == null)
            {
                return true;
            }

            return collection.Count < 1;
        }
    }
}
