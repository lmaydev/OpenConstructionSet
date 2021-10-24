#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Collections](index.md#OpenConstructionSet_Collections 'OpenConstructionSet.Collections').[OcsCollection&lt;T&gt;](CpJitxHTJ7jJqLOu30sQbg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;')
## OcsCollection&lt;T&gt;.Insert(int, T) Method
Inserts an item to the [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1') at the specified index.
```csharp
public void Insert(int index, T item);
```
#### Parameters
<a name='OpenConstructionSet_Collections_OcsCollection_T__Insert(int_T)_index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index at which [item](QUGGGYynJ5EtaOIbJa1yeA.md#OpenConstructionSet_Collections_OcsCollection_T__Insert(int_T)_item 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Insert(int, T).item') should be inserted.
  
<a name='OpenConstructionSet_Collections_OcsCollection_T__Insert(int_T)_item'></a>
`item` [T](CpJitxHTJ7jJqLOu30sQbg.md#OpenConstructionSet_Collections_OcsCollection_T__T 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.T')  
The object to insert into the [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1').
  
#### Exceptions
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
[index](QUGGGYynJ5EtaOIbJa1yeA.md#OpenConstructionSet_Collections_OcsCollection_T__Insert(int_T)_index 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Insert(int, T).index') is not a valid index in the [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1').
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
The [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1') is read-only.

Implements [Insert(int, T)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1.Insert#System_Collections_Generic_IList_1_Insert_System_Int32,_0_ 'System.Collections.Generic.IList`1.Insert(System.Int32,`0)')  
