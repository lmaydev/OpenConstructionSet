using OpenConstructionSet.Data;
using OpenConstructionSet.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenConstructionSet.Collections
{
    public class OcsRefDictionary<T> : IRevertibleChangeTracking, IOcsDictionary<T>, IClearable
        where T : class
    {
        internal readonly OcsDictionary<T> items;

        public OcsRefDictionary() => items = new();

        public OcsRefDictionary(IDictionary<string, T> items) => this.items = new(items);

        public T this[string key] => items[key];

        public IEnumerable<string> Keys => items.Keys;

        public IEnumerable<T> Values => items.Values;

        public int Count => items.Count;

        public IReadOnlyCollection<string> Added => items.Added;

        public IReadOnlyCollection<string> Modified => items.Modified;

        public IReadOnlyDictionary<string, T> Removed => items.Removed;

        public bool IsChanged => items.IsChanged;

        IReadOnlyDictionary<string, T> IOcsDictionary<T>.OriginalValues => items.OriginalValues;

        public bool ChildrenSupportTracking => items.ChildrenSupportTracking;

        public bool ChildrenSupportRevert => items.ChildrenSupportRevert;

        public void Clear()
        {
            items.Clear();
        }

        public bool ContainsKey(string key) => items.ContainsKey(key);

        public bool Remove(string key) => items.Remove(key);

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator() => items.GetEnumerator();

        public void RejectChanges()
        {
            items.RejectChanges();
        }

        public bool TryGetValue(string key, out T value) => items.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        void IChangeTracking.AcceptChanges()
        {
            (items as IChangeTracking)?.AcceptChanges();
        }

        public DictionaryChanges<T> GetChanges()
        {
            return ((IOcsDictionary<T>)items).GetChanges();
        }
    }
}
