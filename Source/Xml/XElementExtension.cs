using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Gremlins.Xml
{
    public static class XElementExtension
    {
        /// <summary>
        /// Returns one and only one child of specified element
        /// </summary>
        /// <param name="e">Element</param>
        /// <returns>Child element</returns>
        public static XElement XOne(this XElement e)
        {
            var childs = e.Elements();
            if (childs.Count() == 0)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OneChildElementExpected, e.Name.LocalName));
            if (childs.Count() > 1)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OneChildElementExpected, e.Name.LocalName));
            return childs.First();
        }

        /// <summary>
        /// Returns one and only one child of specified element with specified name
        /// </summary>
        /// <param name="e">Element</param>
        /// <param name="name">Child element name</param>
        /// <returns>Child element</returns>
        public static XElement XOne(this XElement e, string name)
        {
            var childs = e.Elements(name);
            if (childs.Count() > 1)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OneExactChildElementExpected, e.Name.LocalName, name));
            if (childs.Count() == 0)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_OneExactChildElementExpected, e.Name.LocalName, name));
            return childs.First();
        }

        public static XElement XZeroOrOne(this XElement e)
        {
            var childs = e.Elements();
            if (childs.Count() > 1)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_ZeroOrOneChildElementExpected, e.Name.LocalName));
            return childs.FirstOrDefault();
        }

        public static XElement XZeroOrOne(this XElement e, string name)
        {
            var childs = e.Elements(name);
            if (childs.Count() > 1)
                throw new FormatException(string.Format(Core.Properties.Resources.XParse_ZeroOrOneExactChildElementExpected, e.Name.LocalName, name));
            return childs.FirstOrDefault();
        }

        public static IEnumerable<XElement> XManyOrEmpty(this XElement x, string path)
        {
            if (x == null)
                return new XElement[0];

            var parts = path.Split('/');
            XElement current = x;

            for (int i = 0; i < parts.Length; i++)
            {
                if (current == null)
                    return new XElement[0];
                if (i == parts.Length - 1)
                    if (parts[i] == "*")
                        return current.Elements();
                    else
                        return current.Elements(parts[i]);
                else
                    current = XElementExtension.XZeroOrOne(current, parts[i]);
            }

            throw new FormatException(string.Format(Core.Properties.Resources.XParse_ElementNotFound, path));
        }
    }
}
