using System;
using System.Collections.Generic;

namespace Calabonga.Utils.Extensions
{
    /// <summary>
    /// EnumHelper Attribute
    /// Provides a general-purpose attribute that lets you specify localizable strings
    /// for types and members of entity partial classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayNamesAttribute : Attribute
    {
        public DisplayNamesAttribute(params string[] values)
        {
            Names = values;
        }

        public IEnumerable<string> Names { get; }
    }
}