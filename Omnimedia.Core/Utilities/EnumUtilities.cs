using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Omnimedia.Core.Utilities
{
    public static class EnumUtilities
    {
        /// <summary>
        /// Creates a SelectList for an Enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selected">The selected value.</param>
        /// <returns></returns>
        public static SelectList SelectListFor<T>(T selected) where T : struct
        {
            Type type = typeof(T);

            if (type.IsEnum)
            {
                return new SelectList(
                    Enum.GetValues(type).Cast<Enum>().Select(e => new
                    {
                        Value = Convert.ToInt32(e),
                        Label = e.GetDescription()
                    }), "Value", "Label", Convert.ToInt32(selected));
            }

            return null;
        }

        /// <summary>
        /// Gets the description of an Enum member.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetDescription<TEnum>(this TEnum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                    return ((DescriptionAttribute)attributes[0]).Description;
            }

            return value.ToString();
        }

        /// <summary>
        /// Gets the enum member.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TEnum GetEnumMember<TEnum>(int value)
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), value);
        }
    }
}