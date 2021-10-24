using System.Collections;

namespace OpenConstructionSet.Collections;

/// <summary>
/// Custom collection that prevents items with duplicate identifiers being added.
/// </summary>
/// <typeparam name="T">The type of items contained by the collection.</typeparam>
public abstract class OcsCollection<T> : IList<T>
{
    /// <summary>
    /// Internal list storing the items.
    /// </summary>
    protected readonly List<T> list;

    /// <summary>
    /// Create a new empty collection.
    /// </summary>
    public OcsCollection() => list = new();

    /// <summary>
    /// Create a collection from the provided colleciton.
    /// </summary>
    /// <param name="collection"></param>
    public OcsCollection(IEnumerable<T> collection) => list = new(collection);

    /// <inheritdoc/>
    public T this[int index] { get => list[index]; set => Insert(index, value); }

    /// <inheritdoc/>
    public int Count => list.Count;

    /// <inheritdoc/>
    public bool IsReadOnly => false;

    /// <inheritdoc/>
    public void Add(T item)
    {
        RemoveById(GetId(item));
        list.Add(item);
    }

    /// <inheritdoc/>
    public void Clear() => list.Clear();

    /// <inheritdoc/>
    public bool Contains(T item) => list.Contains(item);

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

    /// <inheritdoc/>
    public int IndexOf(T item) => list.IndexOf(item);

    /// <inheritdoc/>
    public void Insert(int index, T item)
    {
        RemoveById(GetId(item));
        list.Insert(index, item);
    }

    /// <summary>
    /// When implemented in child classes will return the identifier of the given item.
    /// </summary>
    /// <param name="item">The item who's identifier is needed.</param>
    /// <returns>The identifier of the provided item.</returns>
    protected abstract string GetId(T item);

    /// <inheritdoc/>
    public bool Remove(T item) => list.Remove(item);

    /// <inheritdoc/>
    public void RemoveAt(int index) => list.RemoveAt(index);

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

    /// <summary>
    /// Find an item from it's identifier.
    /// </summary>
    /// <param name="id">The identifier of the item to look for.</param>
    /// <returns>The item with a matching identifier if found; otherwise, <c>null</c></returns>
    public T? FindById(string id) => list.Find(i => GetId(i) == id);

    /// <summary>
    /// Find the index of an item with the given identifier.
    /// </summary>
    /// <param name="id">The identifier of the item to look for.</param>
    /// <returns>The index of the item with a matching identifier if found; otherwise, <c>-1</c></returns>
    public int FindIndexById(string id) => list.FindIndex(i => GetId(i) == id);

    /// <summary>
    /// Attempt to remove an item with a matching identifier.
    /// </summary>
    /// <param name="id">The identifier of the item to remove.</param>
    /// <returns><c>true</c> if an item with the match identifier was found and removed; otherwise, <c>false</c></returns>
    public bool RemoveById(string id)
    {
        var index = FindIndexById(id);

        if (index > -1)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }
}
