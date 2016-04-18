using System.Collections.Generic;

namespace Gremlins.Collections.Generic
{
    public interface IIndexedEnumerable<TKey, TValue> : IEnumerable<TValue>
    {
        TValue this[TKey index] { get; }
    }
}
