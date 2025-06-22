using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Calabonga.Utils.Extensions
{
    /// <summary>
    /// Enum extensions
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Enumerate with Index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>Tuple</returns>
        [DebuggerStepThrough]
        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
    }
}
