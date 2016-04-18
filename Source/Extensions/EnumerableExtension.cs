using Gremlins;
using System.Linq;

namespace System.Collections.Generic
{
    public static class EnumerableExtension
    {
        public static int IndexOf<T>(this IEnumerable<T> collection, Func<T, bool> selector)
        {
            int index = 0;
            foreach (var item in collection)
            {
                if (selector(item))
                    return index;
                index++;
            }
            return -1;
        }               

        public static T Random<T>(this IEnumerable<T> collection)
        {
        	if (collection == null)
        		throw new ArgumentNullException("collection");
        	var temp = collection.ToArray();
        	if (temp.Length == 0)
        		return default(T);
        	return temp[RandomGenerator.Int32(0, temp.Length)];
        }

        public static IEnumerable<T> Random<T>(this IEnumerable<T> collection, int count)
        {
            if (count <= 0)
                throw new ArgumentException("Значение должно быть положительным числом", "count");

            return Random(collection, Convert.ToUInt32(count));
        }

        public static IEnumerable<T> Random<T>(this IEnumerable<T> collection, uint count)
        {
        	if (collection == null)
        		throw new ArgumentNullException("collection");
        	var temp = collection.ToList();
        	if (temp.Count < count)
        		throw new ArgumentException("collection.Length < count");
        	var result = new List<T>();
        	for (int i = 0; i < count; i++)
        	{
        		T t = temp.Random();
        		temp.Remove(t);
        		result.Add(t);
        	}
        	return result;
        }
    }
}
