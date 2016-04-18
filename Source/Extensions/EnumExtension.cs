using System.ComponentModel;

namespace System
{
    public static class EnumHelper
    {
        public static T? GetNullableValue<T>(string value)
            where T : struct
        {
            if (value == null)
                return null;
            T result;
            if (Enum.TryParse<T>(value, out result))
                return result;
            return null;
        }

        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null)
                return default(string);

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Description;

            return value.ToString();
        }
    }
}
