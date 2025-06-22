using System.Diagnostics;

namespace Calabonga.Utils.Extensions
{
    /// <summary>
    /// Extensions for integer
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Indicates whether the specified int is null or a zero
        /// </summary>
        /// <param name="source">Value to check</param>
        /// <returns>
        /// true if the value parameter is null or a zero; otherwise, false
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsEmpty(this int? source)
        {
            return source == null || source == 0;
        }
    }
}
