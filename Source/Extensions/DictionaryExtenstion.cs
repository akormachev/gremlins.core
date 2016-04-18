using System.Linq;

namespace System.Collections.Generic
{
    public static class DictionaryExtenstion
    {
        [Obsolete("Remove this method.")]
        public static void Remove<TKey, TValue>(this IDictionary<TKey, TValue> list, Func<TValue, bool> selector)
        {
            var removeList = new List<TKey>();
            foreach (var x in list)
                if (selector(x.Value))
                    removeList.Add(x.Key);
            foreach (var x in removeList)
                list.Remove(x);
        }

        public static IEnumerable<TValue> Where<TKey, TValue>(this IDictionary<TKey, TValue> list, Func<TValue, bool> selector)
        {
            return list.Values.Where(x => selector(x));
        }
    }
}
