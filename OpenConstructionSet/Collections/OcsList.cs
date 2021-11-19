using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Collections;

/// <summary>
/// String keyed list of data models.
/// </summary>
/// <typeparam name="T">The data model.</typeparam>
public class OcsList<T> : SortedList<string, T>
    where T : IDataModel
{
    /// <summary>
    /// Creates an empty <c>OcsList</c>
    /// </summary>
    public OcsList()
    {
    }

    /// <summary>
    /// Creates a <c>OcsList</c> populated with the passed collection.
    /// </summary>
    /// <param name="collection"></param>
    public OcsList(IEnumerable<T> collection)
    {
        AddRange(collection);
    }

    /// <summary>
    /// Get an item from the collection by it's key.
    /// </summary>
    /// <param name="key">The string identifier used for this data model.</param>
    /// <returns>The item if found or throws an exception.</returns>
    public new T this[string key] { get => base[key]; }

    /// <summary>
    /// Adds a new data model to the collection.
    /// Key is ignored and the data model's key will be used.
    /// Cannot use duplicate keys.
    /// </summary>
    /// <param name="key">Ignored. Key from <c>value</c> is used.</param>
    /// <param name="value">The data model to add.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Public API")]
    public new void Add(string key, T value) => Insert(value, true);

    private void Insert(T value, bool add)
    {
        if (IndexOfKey(value.Key) > -1 && add)
        {
            throw new InvalidOperationException($"Key \"{value.Key}\" already exists");
        }

        base[value.Key] = value;
    }

    /// <summary>
    /// Adds a data model to the collection.
    /// If the model's key is already used the value will be replaced.
    /// </summary>
    /// <param name="value">The data models to add/update.</param>
    public void Update(T value) => Insert(value, false);

    /// <summary>
    /// Adds a data model to the collection.
    /// If any of the models' keys is already used the value will be replaced.
    /// </summary>
    /// <param name="values">The data models to add/update.</param>
    public void UpdateRange(IEnumerable<T> values) => values.ForEach(v => Insert(v, false));

    /// <summary>
    /// Adds a new data model to the collection.
    /// Model's key must be unique.
    /// </summary>
    /// <param name="value">The data model to add.</param>
    public void Add(T value) => Insert(value, true);

    /// <summary>
    /// Add's the provided data models to collection.
    /// </summary>
    /// <param name="values">The data models to add.</param>
    public void AddRange(IEnumerable<T> values) => values.ForEach(Add);
}