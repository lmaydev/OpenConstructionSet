using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Models
{
    public class PropertyTracker : IRevertibleChangeTracking
    {
        private Dictionary<string, object> values = new();
        private Dictionary<string, object> oldValues = new();

        private readonly HashSet<string> changed = new();

        public bool IsChanged => changed.Count > 0;

        public T Get<T>(string name) => (T)values[name];

        public T GetOld<T>(string name) => (T)oldValues[name];

        public void Set<T>(string name, [DisallowNull] T value)
        {
            if (!values.ContainsKey(name))
            {
                oldValues.Add(name, value);
            }

            values[name] = value;

            if (oldValues[name].Equals(value))
            {
                changed.Remove(name);
            }
            else
            {
                changed.Add(name);
            }
        }

        public bool Modified(string name) => changed.Contains(name);

        public void AcceptChanges()
        {
            oldValues = new(values);

            changed.Clear();
        }

        public void RejectChanges()
        {
            values = new(oldValues);

            changed.Clear();
        }

        public void Clear()
        {
            oldValues.Clear();
            values.Clear();

            changed.Clear();
        }
    }
}
