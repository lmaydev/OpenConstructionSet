using OpenConstructionSet.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OpenConstructionSet.Collections
{
    public class OcsDictionary<T> : IDictionary<string, T>, IReadOnlyDictionary<string, T>, IRevertibleChangeTracking, IClearable, IOcsDictionary<T>
    {
        private static readonly Dictionary<Type, (bool, bool)> childSupport = new();

        private readonly HashSet<string> added = new();
        private readonly HashSet<string> modified = new();
        private readonly Dictionary<string, T> removed = new();
        private Dictionary<string, T> originalValues;
        private Dictionary<string, T> currentValues;

        public ICollection<string> Keys => currentValues.Keys;
        public ICollection<T> Values => currentValues.Values;
        public int Count => currentValues.Count;
        public bool IsReadOnly => false;
        public IReadOnlyDictionary<string, T> OriginalValues => originalValues;
        public IReadOnlyDictionary<string, T> Removed => removed;
        public IReadOnlyCollection<string> Added => added;
        public IReadOnlyCollection<string> Modified => modified;

        IEnumerable<string> IReadOnlyDictionary<string, T>.Keys => currentValues.Keys;
        IEnumerable<T> IReadOnlyDictionary<string, T>.Values => currentValues.Values;

        public bool ChildrenSupportTracking { get; }
        public bool ChildrenSupportRevert { get; }

        public bool IsChanged => added.Count > 0 || removed.Count > 0 || modified.Count > 0 || ChildrenChanged();

        public OcsDictionary()
        {
            currentValues = new();
            originalValues = new();

            var (tracking, revert) = CheckChildType();

            ChildrenSupportTracking = tracking;
            ChildrenSupportRevert = revert;
        }

        private static (bool, bool) CheckChildType()
        {
            var type = typeof(T);

            if (!childSupport.TryGetValue(type, out var results))
            {
                if (typeof(IRevertibleChangeTracking).IsAssignableFrom(type))
                {
                    // Tracking and revert
                    results = (true, true);
                }
                else if (typeof(IChangeTracking).IsAssignableFrom(type))
                {
                    // Just tracking
                    results = (true, false);
                }
                else
                {
                    // FA
                    results = (false, false);
                }

                childSupport[type] = results;
            }

            return results;
        }

        public OcsDictionary(IDictionary<string, T> original)
        {
            currentValues = new(original);
            originalValues = new(original);

            ChildrenSupportTracking = default(T) is IChangeTracking;
            ChildrenSupportRevert = default(T) is IRevertibleChangeTracking;
        }

        private bool ChildrenChanged() => ChildrenSupportTracking && currentValues.Any(p => p.Value is IChangeTracking t && t.IsChanged);

        public void Clear()
        {
            currentValues.Clear();

            added.Clear();
            modified.Clear();

            foreach (var pair in originalValues)
            {
                removed.Add(pair.Key, pair.Value);
            }
        }

        protected virtual void Insert(string key, T value, bool add)
        {
            if (add && currentValues.ContainsKey(key))
            {
                throw new ArgumentException("Cannot add duplicate key");
            }

            currentValues[key] = value;

            removed.Remove(key);

            if (originalValues.TryGetValue(key, out var originalValue))
            {
                if (originalValue!.Equals(value))
                {
                    modified.Remove(key);
                }
                else
                {
                    modified.Add(key);
                }
            }
            else
            {
                added.Add(key);
            }
        }

        public bool Remove(string key)
        {
            bool sucess = currentValues.Remove(key);

            if (!sucess)
            {
                return false;
            }

            // Remove tracking
            added.Remove(key);
            modified.Remove(key);

            if (originalValues.TryGetValue(key, out var value))
            {
                if (value is IRevertibleChangeTracking tracking)
                {
                    tracking.RejectChanges();
                }

                // Track if in the original list
                removed.Add(key, value);
            }

            return true;
        }

        public void Add(string key, T value) => Insert(key, value, true);

        public bool Remove(KeyValuePair<string, T> item) => Remove(item);

        public T this[string key]
        {
            get => currentValues[key];

            set => Insert(key, value, false);
        }

        public void Add(KeyValuePair<string, T> item) => Add(item.Key, item.Value);

        public bool Contains(KeyValuePair<string, T> item) => ((IDictionary<string, T>)currentValues).Contains(item);

        public bool ContainsKey(string key) => currentValues.ContainsKey(key);

        public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        {
            ((IDictionary<string, T>)currentValues).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator() => currentValues.GetEnumerator();

        public bool TryGetValue(string key, out T value) => currentValues.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => currentValues.GetEnumerator();

        public void RejectChanges()
        {
            modified.Clear();
            added.Clear();
            removed.Clear();

            currentValues = new(originalValues);

            if (ChildrenSupportRevert)
            {
                foreach (var value in currentValues.Values.Cast<IRevertibleChangeTracking>())
                {
                    value.RejectChanges();
                }
            }
        }

        void IChangeTracking.AcceptChanges()
        {
            modified.Clear();
            added.Clear();
            removed.Clear();

            originalValues = new(currentValues);

            if (ChildrenSupportTracking)
            {
                foreach (var value in currentValues.Values.Cast<IChangeTracking>())
                {
                    value.AcceptChanges();
                }
            }
        }

        public DictionaryChanges<T> GetChanges() => new(this);
    }
}
