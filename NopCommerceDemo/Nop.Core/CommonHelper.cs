using Nop.Core.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core
{
    /// <summary>
    /// Represents a common helper
    /// </summary>
    public partial class CommonHelper
    {

        public static TypeConverter GetNopCustomTypeConverter(Type type)
        {
            // we can't use the following code in order to register our custom
            // type descriptors
            //TypeDescriptor.AddAttributes(typeof(List<int>), new TypeConverterAttribute(typeof(GenericListTypeConverter<int>)));
            // so we do it manually here

            if (type == typeof(List<int>))
                return new GenericListTypeConverter<int>();
            if (type == typeof(List<decimal>))
                return new GenericListTypeConverter<decimal>();
            if (type == typeof(List<string>))
                return new GenericListTypeConverter<string>();
            //if(type==typeof(Shi))
        }

        /// <summary>
        /// Converts a value to a destination type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="destinationType">The type to convert the value to.</param>
        /// <returns></returns>
        public static object To(object value, Type destinationType)
        {
            return To(value, destinationType, CultureInfo.InvariantCulture);
        }

        public static object To(object value, Type destinationType, CultureInfo culture)
        {
            if (value != null)
            {
                var sourceType = value.GetType();

                //TypeConverter destinationConverter=
            }
        }


        /// <summary>
        /// Converts a value to a destination type.
        /// </summary>
        /// <typeparam name="T">The type to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static T To<T>(object value)
        {
            //return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            return (T)To(value, typeof(T));
        }

    }
}
