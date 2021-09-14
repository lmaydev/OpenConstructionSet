using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OpenConstructionSet.Collections
{
    public class ValuePair<TValue>
    {
        public TValue OldValue { get; set; }
        public TValue NewValue { get; set; }

        public ValuePair(IOcsDictionary<TValue> dictionary, string key)
        {
            OldValue = dictionary.OriginalValues[key];
            NewValue = dictionary[key];
        }

        public ValuePair(TValue oldValue, TValue newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public class DictionaryChanges<TValue>
    {
        public IReadOnlyDictionary<string, TValue> Added { get; }
        public IReadOnlyDictionary<string, TValue> Modified { get; }
        public IReadOnlyDictionary<string, TValue> Removed { get; }

        public IReadOnlyDictionary<string, TValue> Unmodified { get; }

        public DictionaryChanges(IOcsDictionary<TValue> dictionary)
        {
            Removed = dictionary.Removed;

            Added = dictionary.Added.ToDictionary(k => k, k => dictionary[k]);

            var modified = dictionary.Modified.ToDictionary(k => k, k => dictionary[k]);

            Modified = modified;

            var usedKeys = new HashSet<string>(Added.Keys.Union(Modified.Keys).Union(Removed.Keys));

            if (!dictionary.ChildrenSupportTracking)
            {
                Unmodified = dictionary.Where(p => !usedKeys.Contains(p.Key)).ToDictionary(p => p.Key, p => p.Value);
            }
            else
            {
                var unmodified = new Dictionary<string, TValue>();

                foreach (var item in dictionary)
                {
                    if (usedKeys.Contains(item.Key))
                    {
                        continue;
                    }

                    if (item.Value is IChangeTracking tracker && tracker.IsChanged)
                    {
                        modified[item.Key] = item.Value;
                    }
                    else
                    {
                        unmodified[item.Key] = item.Value;
                    }
                }

                Unmodified = unmodified;
            }
        }
    }
}
