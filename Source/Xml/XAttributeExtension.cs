using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Gremlins.Xml
{
    public static class XAttributeExtension
    {
        public static bool XBool(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            bool value;
            if (!bool.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_LogicalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static byte XByte(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            byte value;
            if (!byte.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static char XChar(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            char value;
            if (!char.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_SymbolAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static DateTime XDateTime(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            DateTime value;
            if (!System.DateTime.TryParse(attr.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_DateAttribiteExpected, e.Name.LocalName, name));
            return value;
        }

        public static bool XDBool(this XElement e, string name, bool defaultValue)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                return defaultValue;
            bool value;
            if (!bool.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static T1 XEnum<T1>(this XElement e, string name)
            where T1 : struct
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            T1 value;
            if (!System.Enum.TryParse<T1>(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_EnumerationAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static Guid XGuid(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            Guid value;
            if (!System.Guid.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_UIDAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static short XInt16(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            short value;
            if (!short.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static int XInt32(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            int value;
            if (!int.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static long XInt64(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            long value;
            if (!long.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static bool? XNBool(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                return null;
            bool value;
            if (!bool.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_LogicalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static byte? XNByte(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                return null;
            byte value;
            if (!byte.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static T1? XNEnum<T1>(this XElement e, string name)
            where T1 : struct
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                return null;
            T1 value;
            if (!System.Enum.TryParse<T1>(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_EnumerationAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static int? XNInt32(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                return null;
            int value;
            if (!int.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static ushort? XNUInt16(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                return null;
            ushort value;
            if (!ushort.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static float? XNSingle(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                return null;
            float value;
            if (!float.TryParse(attr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_NumeralAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static string XNString(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                return null;
            return attr.Value;
        }

        public static sbyte XSByte(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            sbyte value;
            if (!sbyte.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static float XSingle(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            float value;
            if (!float.TryParse(attr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_NumeralAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static string XString(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            return attr.Value;
        }

        public static string[] XStringArray(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            return attr.Value.Split(',').Select(x => x.Trim()).ToArray();
        }

        public static ushort XUInt16(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            ushort value;
            if (!ushort.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static uint XUInt32(this XElement e, string name)
        {
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            uint value;
            if (!uint.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }

        public static ulong XUInt64(this XElement e, string name)
        {            
            XAttribute attr = e.Attribute(name);
            if (attr == null)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_AttributeMissed, e.Name.LocalName, name));
            ulong value;
            if (!ulong.TryParse(attr.Value, out value))
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OrdinalAttributeExpected, e.Name.LocalName, name));
            return value;
        }
    }
}
