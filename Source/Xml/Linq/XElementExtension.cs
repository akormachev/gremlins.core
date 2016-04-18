using Gremlins.Collections.Generic;
using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Gremlins.Xml.Linq
{
    public static class XElementExtension
    {
        public static DateTime GetDateTime(this XElement element, Expression<Func<DateTime>> propertyExpression)
        {
            return GetDateTime(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static DateTime GetDateTime(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return DateTime.MinValue;

            DateTime result;
            if (DateTime.TryParse(attribute.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                return result;

            return DateTime.MinValue;
        }
        public static decimal GetDecimal(this XElement element, Expression<Func<decimal>> propertyExpression)
        {
            return GetDecimal(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static decimal GetDecimal(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return 0m;

            decimal result;
            if (Decimal.TryParse(attribute.Value, out result))
                return result;

            return 0m;
        }
        public static double GetDouble(this XElement element, Expression<Func<double>> propertyExpression)
        {
            return GetDouble(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static double GetDouble(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return 0d;

            double result;
            if (double.TryParse(attribute.Value, out result))
                return result;

            return 0d;
        }        
        public static TValue GetEntity<TKey, TValue>(this XElement element, Expression<Func<TValue>> propertyExpression, IIndexedEnumerable<TKey, TValue> entitySource, Func<string, TKey> keySelector)
        {
            return GetEntity<TKey, TValue>(element, PropertySupport.ExtractPropertyName(propertyExpression), entitySource, keySelector);
        }
        public static TValue GetEntity<TKey, TValue>(this XElement element, string name, IIndexedEnumerable<TKey, TValue> entitySource, Func<string, TKey> keySelector)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return default(TValue);

            return entitySource[keySelector(attribute.Value)];
        }
        public static TEnum GetEnum<TEnum>(this XElement element, Expression<Func<TEnum>> propertyExpression)
            where TEnum : struct, IConvertible
        {
            return GetEnum<TEnum>(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static TEnum GetEnum<TEnum>(this XElement element, string name)
            where TEnum : struct, IConvertible
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return default(TEnum);

            TEnum result;
            if (Enum.TryParse<TEnum>(attribute.Value, out result))
                return result;

            return default(TEnum);
        }
        public static Guid GetGuid(this XElement element, Expression<Func<Guid>> propertyExpression)
        {
            return GetGuid(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static Guid GetGuid(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return Guid.Empty;

            Guid result;
            if (Guid.TryParse(attribute.Value, out result))
                return result;

            return Guid.Empty;
        }
        public static int GetInt32(this XElement element, Expression<Func<int>> propertyExpression)
        {
            return GetInt32(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static int GetInt32(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return 0;

            int result;
            if (int.TryParse(attribute.Value, out result))
                return result;

            return 0;
        }
        public static DateTime? GetNDateTime(this XElement element, Expression<Func<DateTime?>> propertyExpression)
        {
            return GetNDateTime(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static DateTime? GetNDateTime(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return null;

            DateTime result;
            if (DateTime.TryParse(attribute.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                return result;

            return null;
        }
        public static sbyte GetSByte(this XElement element, Expression<Func<sbyte>> propertyExpression)
        {
            return GetSByte(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static sbyte GetSByte(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return 0;

            sbyte result;
            if (sbyte.TryParse(attribute.Value, out result))
                return result;

            return 0;
        }
        public static float GetSingle(this XElement element, Expression<Func<float>> propertyExpression)
        {
            return GetSingle(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static float GetSingle(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return 0f;

            float result;
            if (float.TryParse(attribute.Value, out result))
                return result;

            return 0f;
        }
        public static string GetString(this XElement element, Expression<Func<string>> propertyExpression)
        {
            return GetString(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static string GetString(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return null;

            return attribute.Value;
        }
        public static TimeSpan GetTimeSpan(this XElement element, Expression<Func<TimeSpan>> propertyExpression)
        {
            return GetTimeSpan(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static TimeSpan GetTimeSpan(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return TimeSpan.MinValue;

            TimeSpan result;
            if (TimeSpan.TryParse(attribute.Value, out result))
                return result;

            return TimeSpan.MinValue;
        }
        public static ushort GetUInt16(this XElement element, Expression<Func<ushort>> propertyExpression)
        {
            return GetUInt16(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static ushort GetUInt16(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return 0;

            ushort result;
            if (ushort.TryParse(attribute.Value, out result))
                return result;

            return 0;
        }
        public static uint GetUInt32(this XElement element, Expression<Func<uint>> propertyExpression)
        {
            return GetUInt32(element, PropertySupport.ExtractPropertyName(propertyExpression));
        }
        public static uint GetUInt32(this XElement element, string name)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                return 0;

            uint result;
            if (uint.TryParse(attribute.Value, out result))
                return result;

            return 0;
        }
        public static bool SetDateTime(this XElement element, Expression<Func<DateTime>> propertyExpression, DateTime value)
        {
            return SetDateTime(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetDateTime(this XElement element, string name, DateTime value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString(CultureInfo.InvariantCulture))
                return false;

            attribute.Value = value.ToString(CultureInfo.InvariantCulture);

            return true;
        }
        public static bool SetDecimal(this XElement element, Expression<Func<decimal>> propertyExpression, decimal value)
        {
            return SetDecimal(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetDecimal(this XElement element, string name, decimal value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        public static bool SetDouble(this XElement element, Expression<Func<double>> propertyExpression, double value)
        {
            return SetDouble(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetDouble(this XElement element, string name, double value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        public static bool SetEntity<TKey, TValue>(this XElement element, Expression<Func<TValue>> propertyExpression, IIndexedEnumerable<TKey, TValue> entitySource, TValue value, Func<TValue,string> keySelector)
        {
            return SetEntity<TKey, TValue>(element, PropertySupport.ExtractPropertyName(propertyExpression), entitySource, value, keySelector);
        }
        public static bool SetEntity<TKey, TValue>(this XElement element, string name, IIndexedEnumerable<TKey, TValue> entitySource, TValue value, Func<TValue, string> valueSelector)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (value == null)
                return !string.IsNullOrEmpty(attribute.Value);

            if (attribute.Value == valueSelector(value))
                return false;

            attribute.Value = valueSelector(value);

            return true;
        }
        public static bool SetEnum<TEnum>(this XElement element, Expression<Func<TEnum>> propertyExpression, TEnum value)
            where TEnum : struct, IConvertible
        {
            return SetEnum(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetEnum<TEnum>(this XElement element, string name, TEnum value)
            where TEnum: struct, IConvertible
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        public static bool SetGuid(this XElement element, Expression<Func<Guid>> propertyExpression, Guid value)
        {
            return SetGuid(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetGuid(this XElement element, string name, Guid value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        public static bool SetInt32(this XElement element, Expression<Func<int>> propertyExpression, int value)
        {
            return SetInt32(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetInt32(this XElement element, string name, int value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }

        public static bool SetNDateTime(this XElement element, Expression<Func<DateTime?>> propertyExpression, DateTime? value)
        {
            return SetNDateTime(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetNDateTime(this XElement element, string name, DateTime? value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (value == null)
                return !string.IsNullOrEmpty(attribute.Value);

            if (attribute.Value == value.Value.ToString(CultureInfo.InvariantCulture))
                return false;

            attribute.Value = value.Value.ToString(CultureInfo.InvariantCulture);

            return true;
        }
        public static bool SetSByte(this XElement element, Expression<Func<sbyte>> propertyExpression, sbyte value)
        {
            return SetSByte(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetSByte(this XElement element, string name, sbyte value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        public static bool SetSingle(this XElement element, Expression<Func<float>> propertyExpression, float value)
        {
            return SetSingle(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetSingle(this XElement element, string name, float value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        public static bool SetString(this XElement element, Expression<Func<string>> propertyExpression, string value)
        {
            return SetString(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetString(this XElement element, string name, string value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value)
                return false;

            attribute.Value = value;

            return true;
        }
        public static bool SetTimeSpan(this XElement element, Expression<Func<TimeSpan>> propertyExpression, TimeSpan value)
        {
            return SetTimeSpan(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetTimeSpan(this XElement element, string name, TimeSpan value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        public static bool SetUInt16(this XElement element, Expression<Func<ushort>> propertyExpression, ushort value)
        {
            return SetUInt16(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetUInt16(this XElement element, string name, ushort value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        public static bool SetUInt32(this XElement element, Expression<Func<uint>> propertyExpression, uint value)
        {
            return SetUInt32(element, PropertySupport.ExtractPropertyName(propertyExpression), value);
        }
        public static bool SetUInt32(this XElement element, string name, uint value)
        {
            var attribute = element.Attribute(name);
            if (attribute == null)
                attribute = element.AddAttribute(new XAttribute(name, string.Empty));

            if (attribute.Value == value.ToString())
                return false;

            attribute.Value = value.ToString();

            return true;
        }
        private static XAttribute AddAttribute(this XElement element, XAttribute attribute)
        {
            element.Add(attribute);
            return attribute;
        }
    }
}
