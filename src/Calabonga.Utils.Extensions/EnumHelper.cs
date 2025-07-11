﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Calabonga.Utils.Extensions
{
    /// <summary>
    /// Enum Helper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class EnumHelper<T> where T : struct
    {
        /// <summary>
        /// Returns Enum with DisplayNames
        /// </summary>
        [DebuggerStepThrough]
        public static Dictionary<T, string> GetValuesWithDisplayNamesByMask(T enumValues)
        {
            var list = new Dictionary<T, string>();
            var items = GetValues(enumValues as Enum);

            if (items is null)
            {
                return list;
            }

            foreach (var element in items)
            {
                list.Add(element, GetDisplayValue(element));
            }
            return list;
        }

        /// <summary>
        /// Returns Enum with DisplayNames
        /// </summary>
        [DebuggerStepThrough]
        public static Dictionary<T, string> GetValuesWithDisplayNames()
        {
            var type = typeof(T);
            var r = type.GetEnumValues();
            var list = new Dictionary<T, string>();
            foreach (var element in r)
            {
                list.Add((T)element, GetDisplayValue((T)element));
            }
            return list;
        }

        /// <summary>
        /// Returns values from enum
        /// </summary>
        [DebuggerStepThrough]
        public static IList<T> GetValues()
        {
            return typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fi => (T)Enum.Parse(typeof(T), fi.Name, false))
                .ToList();
        }

        /// <summary>
        /// Returns masked filter
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerStepThrough]
        public static IEnumerable<T> GetValues(Enum mask)
        {
            if (typeof(T).IsSubclassOf(typeof(Enum)) == false)
            {
                throw new ArgumentException();
            }

            foreach (T curValueBit in Enum.GetValues(typeof(T)).Cast<T>())
            {
                var value = curValueBit as Enum;

                if (value is null)
                {
                    continue;
                }

                if (mask.HasFlag(value!))
                {
                    yield return curValueBit;
                }
            }
        }

        /// <summary>
        /// Parse displayValue by string from Enum
        /// </summary>
        /// <param name="value"></param>
        [DebuggerStepThrough]
        public static T Parse(string value)
        {
            var displayName = TryParseDisplayValue(value);
            if (displayName != null)
            {
                return (T)displayName;
            }
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Parse displayValue by string from Enum
        /// </summary>
        /// <param name="value"></param>
        public static T? TryParse(string value)
        {
            if (Enum.TryParse(value, true, out T result))
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// Return attribute to extract data from it
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="value"></param>
        [DebuggerStepThrough]
        public static TAttribute TryGetFromAttribute<TAttribute>(string value)
            where TAttribute : Attribute
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .FirstOrDefault(x => x.Name == value)?
                .GetCustomAttribute<TAttribute>(false);
        }

        /// <summary>
        /// Return attribute to extract data from it
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="value"></param>
        [DebuggerStepThrough]
        public static TAttribute TryGetFromAttribute<TAttribute>(T value)
            where TAttribute : Attribute
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .FirstOrDefault(x => x.Name == value.ToString())?
                .GetCustomAttribute<TAttribute>(false);
        }

        /// <summary>
        /// Parse displayValue by string from Enum
        /// </summary>
        /// <param name="displayValue"></param>
        [DebuggerStepThrough]
        public static T? TryParseDisplayValue(string displayValue)
        {
            var fieldInfos = typeof(T).GetFields();

            foreach (var field in fieldInfos)
            {
                var valuesAttributes = field.GetCustomAttributes(typeof(DisplayNamesAttribute), false) as DisplayNamesAttribute[];
                if (valuesAttributes?.Length > 0)
                {
                    if (valuesAttributes[0].Names.Any())
                    {
                        var exists = valuesAttributes[0].Names.Any(x => x.Equals(displayValue));
                        if (exists)
                        {
                            if (Enum.TryParse(field.Name, true, out T result1))
                            {
                                return result1;
                            }
                        }
                    }
                }

                var descriptionAttributes = field.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (descriptionAttributes?.Length > 0)
                {
                    if (descriptionAttributes[0].ResourceType != null)
                    {
                        // Calabonga: Implement search in resources (resx) (2020-06-26 02:48 EnumHelper)
                        // var stringValue = LookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);
                        return default(T);
                    }

                    var name = descriptionAttributes[0].Name;
                    if (name != null && name.Equals(displayValue, StringComparison.OrdinalIgnoreCase))
                    {
                        if (Enum.TryParse(field.Name, true, out T result1))
                        {
                            return result1;
                        }
                    }

                    if (Enum.TryParse(displayValue, true, out T result2))
                    {
                        return result2;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns values from Enum
        /// </summary>
        [DebuggerStepThrough]
        public static IEnumerable<string> GetNames()
        {
            return typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        /// <summary>
        /// Returns values from Enum or Resource file if exists
        /// </summary>
        [DebuggerStepThrough]
        public static IList<string> GetDisplayValues()
        {
            return typeof(T).HasAttribute<FlagsAttribute>() ? default(IList<string>) : GetNames().Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        private static string LookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (var staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    var resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }

        /// <summary>
        /// Returns display name for Enum
        /// </summary>
        /// <param name="value"></param>
        [DebuggerStepThrough]
        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), true) as DisplayAttribute[];
            if (descriptionAttributes?.Length > 0 && descriptionAttributes[0].ResourceType != null)
            {
                return LookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);
            }

            if (descriptionAttributes == null)
            {
                return string.Empty;
            }

            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> GetUniqueFlags(Enum flags)
        {
            if (!flags.HasAttribute<FlagsAttribute>())
            {
                yield break;
            }

            foreach (var value in Enum.GetValues(flags.GetType()))
            {
                if (!flags.HasFlag((Enum)value))
                {
                    continue;
                }

                yield return (T)value;
            }
        }

    }
}
