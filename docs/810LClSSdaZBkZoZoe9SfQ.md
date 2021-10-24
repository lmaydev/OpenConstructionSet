#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Collections](index.md#OpenConstructionSet_Collections 'OpenConstructionSet.Collections').[OcsCollection&lt;T&gt;](CpJitxHTJ7jJqLOu30sQbg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;')
## OcsCollection&lt;T&gt;.Remove(T) Method
Removes the first occurrence of a specific object from the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1').
```csharp
public bool Remove(T item);
```
#### Parameters
<a name='OpenConstructionSet_Collections_OcsCollection_T__Remove(T)_item'></a>
`item` [T](CpJitxHTJ7jJqLOu30sQbg.md#OpenConstructionSet_Collections_OcsCollection_T__T 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.T')  
The object to remove from the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1').
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if [item](810LClSSdaZBkZoZoe9SfQ.md#OpenConstructionSet_Collections_OcsCollection_T__Remove(T)_item 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Remove(T).item') was successfully removed from the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'); otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool'). This method also returns [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if [item](810LClSSdaZBkZoZoe9SfQ.md#OpenConstructionSet_Collections_OcsCollection_T__Remove(T)_item 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.Remove(T).item') is not found in the original [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1').
#### Exceptions
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
The [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') is read-only.

Implements [Remove(T)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1.Remove#System_Collections_Generic_ICollection_1_Remove__0_ 'System.Collections.Generic.ICollection`1.Remove(`0)')  
