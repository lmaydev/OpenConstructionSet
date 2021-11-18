using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Collections;

public class OcsList<T> : SortedList<string, T>
    where T : IDataModel
{
    public OcsList()
    {
    }

    public OcsList(IEnumerable<T> collection)
    {
        AddRange(collection);
    }

    public new T this[string key] { get => base[key]; }

    public new void Add(string key, T value) => Insert(value, true);

    private void Insert(T value, bool add)
    {
        if (IndexOfKey(value.Key) > -1 && add)
        {
            throw new InvalidOperationException($"Key \"{value.Key}\" already exists");
        }

        base[value.Key] = value;
    }

    public void Update(T value) => Insert(value, false);

    public void Add(T value) => Insert(value, true);

    public void AddRange(IEnumerable<T> values) => values.ForEach(Add);
}