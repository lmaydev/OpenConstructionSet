#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Collections](index.md#OpenConstructionSet_Collections 'OpenConstructionSet.Collections').[OcsCollection&lt;T&gt;](CpJitxHTJ7jJqLOu30sQbg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;')
## OcsCollection&lt;T&gt;.this[int] Property
Gets or sets the element at the specified index.
```csharp
public T this[int index] { get; set; }
```
#### Parameters
<a name='OpenConstructionSet_Collections_OcsCollection_T__this_int__index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index of the element to get or set.
  
#### Property Value
[T](CpJitxHTJ7jJqLOu30sQbg.md#OpenConstructionSet_Collections_OcsCollection_T__T 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.T')
#### Exceptions
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
[index](3yFMgTiFFU6cZdfjrUbf8A.md#OpenConstructionSet_Collections_OcsCollection_T__this_int__index 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.this[int].index') is not a valid index in the [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1').
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
The property is set and the [System.Collections.Generic.IList&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1') is read-only.

Implements [this[int]](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1.Item#System_Collections_Generic_IList_1_Item_System_Int32_ 'System.Collections.Generic.IList`1.Item(System.Int32)')  
