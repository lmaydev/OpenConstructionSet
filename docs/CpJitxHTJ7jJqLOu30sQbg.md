#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Collections](index.md#OpenConstructionSet_Collections 'OpenConstructionSet.Collections')
## OcsCollection&lt;T&gt; Class
Custom collection that prevents items with duplicate identifiers being added.  
```csharp
public abstract class OcsCollection<T> :
System.Collections.Generic.IList<T>,
System.Collections.Generic.ICollection<T>,
System.Collections.Generic.IEnumerable<T>,
System.Collections.IEnumerable
```
#### Type parameters
<a name='OpenConstructionSet_Collections_OcsCollection_T__T'></a>
`T`  
The type of items contained by the collection.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OcsCollection&lt;T&gt;  

Derived  
&#8627; [InstanceCollection](j8W5ea9+YYuv04AThMEs_w.md 'OpenConstructionSet.Collections.InstanceCollection')  
&#8627; [ReferenceCategoryCollection](Z_8mczU4ty2AYSnLk19kjA.md 'OpenConstructionSet.Collections.ReferenceCategoryCollection')  
&#8627; [ReferenceCollection](A_iVrzvkVjBWCRYQ141Zbw.md 'OpenConstructionSet.Collections.ReferenceCollection')  

Implements [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](CpJitxHTJ7jJqLOu30sQbg.md#OpenConstructionSet_Collections_OcsCollection_T__T 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1'), [System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[T](CpJitxHTJ7jJqLOu30sQbg.md#OpenConstructionSet_Collections_OcsCollection_T__T 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](CpJitxHTJ7jJqLOu30sQbg.md#OpenConstructionSet_Collections_OcsCollection_T__T 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  

| Constructors | |
| :--- | :--- |
| [OcsCollection()](craOuc3TXGjgsCOMxbNulA.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.OcsCollection()') | Create a new empty collection.<br/> |
| [OcsCollection(IEnumerable&lt;T&gt;)](ghkVtQ9UpICaOPgwZNIAiw.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.OcsCollection(System.Collections.Generic.IEnumerable&lt;T&gt;)') | Create a collection from the provided colleciton.<br/> |

| Fields | |
| :--- | :--- |
| [list](7dMhSCnCkVjoOJ2CzQOfBw.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.list') | Internal list storing the items.<br/> |

| Properties | |
| :--- | :--- |
| [Count](cqs+7c4NaAxgsYrh+u8LCg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Count') | Gets the number of elements contained in the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'). |
| [IsReadOnly](8N_hMZYueA0pqSL_Uou3aQ.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.IsReadOnly') | Gets a value indicating whether the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') is read-only. |
| [this[int]](3yFMgTiFFU6cZdfjrUbf8A.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.this[int]') | Gets or sets the element at the specified index. |

| Methods | |
| :--- | :--- |
| [Add(T)](iMu8obXVSAAPu7xpMGycsw.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Add(T)') | Adds an item to the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'). |
| [Clear()](GeMevJUmICQvYYCX9ZOlqw.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Clear()') | Removes all items from the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'). |
| [Contains(T)](axY7IHfaxxQP9IgOdRduQw.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Contains(T)') | Determines whether the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') contains a specific value. |
| [CopyTo(T[], int)](vDEM74GZVFdz03itlaF4rg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.CopyTo(T[], int)') | Copies the elements of the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') to an [System.Array](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array'), starting at a particular [System.Array](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array') index. |
| [FindById(string)](rAL7e9hrMaJUzBRmzuhARg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.FindById(string)') | Find an item from it's identifier.<br/> |
| [FindIndexById(string)](1Rcbvrz7g8QYrxxYX+MsNA.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.FindIndexById(string)') | Find the index of an item with the given identifier.<br/> |
| [GetEnumerator()](zheQU9jZjTLKbYJcN0gScw.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.GetEnumerator()') | Returns an enumerator that iterates through the collection. |
| [GetId(T)](ipekOGhDu6jI8RAkJt8YIg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.GetId(T)') | When implemented in child classes will return the identifier of the given item.<br/> |
| [IndexOf(T)](Bz6seVtAz3NgQ1GcU+ZD2A.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.IndexOf(T)') | Determines the index of a specific item in the [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1'). |
| [Insert(int, T)](QUGGGYynJ5EtaOIbJa1yeA.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Insert(int, T)') | Inserts an item to the [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1') at the specified index. |
| [Remove(T)](810LClSSdaZBkZoZoe9SfQ.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Remove(T)') | Removes the first occurrence of a specific object from the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'). |
| [RemoveAt(int)](QYvPhaX2ejmg59zOrF1LaA.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.RemoveAt(int)') | Removes the [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1') item at the specified index. |
| [RemoveById(string)](0XQdw5pAm9uweqevXcTgpQ.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.RemoveById(string)') | Attempt to remove an item with a matching identifier.<br/> |

| Explicit Interface Implementations | |
| :--- | :--- |
| [System.Collections.IEnumerable.GetEnumerator()](PS0tz0JDKt+3HUFHurNlDA.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.System.Collections.IEnumerable.GetEnumerator()') | Returns an enumerator that iterates through a collection. |
