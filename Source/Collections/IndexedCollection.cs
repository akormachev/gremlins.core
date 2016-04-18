using Gremlins.Core.Resources;
using System;
using System.Collections.Generic;

namespace Gremlins.Collections.Generic
{
    public class IndexedCollection<TKey, TValue> : IIndexedCollection<TKey, TValue>
    {

        #region Fields

        private readonly IDictionary<TKey, TValue> _items;

        #endregion

        #region Constructors

        public IndexedCollection()
        {
            _items = new Dictionary<TKey, TValue>();
        }

        public IndexedCollection(IEnumerable<TValue> items, Func<TValue, TKey> selector)
            :this()
        {
            foreach (var item in items)
                _items.Add(selector(item), item);
        }

        public IndexedCollection(IDictionary<TKey, TValue> items)
        {
            _items = items;
        }

        #endregion

        #region Properties

        public ICollection<TKey> Keys
        {
            get { return _items.Keys; }
        }

        public TValue this[TKey index]
        {
            get
            {
                if (_items.ContainsKey(index))
                    return _items[index];
                throw new KeyNotFoundException(string.Format(Errors.KeyNotFound, index));
            }
        }

        #endregion

        #region IEnumerable<TValue> Implementation

        public IEnumerator<TValue> GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable Implementation

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }

        #endregion

        #region Public methods

        public void Add(TKey key, TValue value)
        {
            if (!_items.ContainsKey(key))                
                _items.Add(key, value);
        }

        public bool Contains(TKey key)
        {
            return _items.ContainsKey(key);
        }

        #endregion

    }    
}
