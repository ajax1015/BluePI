using System;
using System.Reflection;

namespace BluePI.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConvertHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        public static TResult Convert<TResult>(object input) where TResult : class
        {
            if (input == null)
            {
                return default(TResult);
            }
            if (input.GetType() == typeof(TResult))
            {
                return (TResult)((object)input);
            }
            return (TResult)((object)Convert(input, typeof(TResult)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object Convert(object input, Type targetType)
        {
            object obj = Activator.CreateInstance(targetType);
            PropertyInfo[] properties = targetType.GetProperties();
            Type type = input.GetType();
            PropertyInfo[] array = properties;
            for (int i = 0; i < array.Length; i++)
            {
                PropertyInfo propertyInfo = array[i];
                if (propertyInfo.CanWrite)
                {
                    PropertyInfo property = type.GetProperty(propertyInfo.Name);
                    if (!(property == null))
                    {
                        object value = property.GetValue(input, null);
                        propertyInfo.SetValue(obj, value, null);
                    }
                }
            }
            return obj;
        }
    }
}