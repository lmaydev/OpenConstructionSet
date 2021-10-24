#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Collections](index.md#OpenConstructionSet_Collections 'OpenConstructionSet.Collections').[OcsCollection&lt;T&gt;](CpJitxHTJ7jJqLOu30sQbg.md 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;')
## OcsCollection&lt;T&gt;.CopyTo(T[], int) Method
Copies the elements of the [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') to an [System.Array](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array'), starting at a particular [System.Array](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array') index.
```csharp
public void CopyTo(T[] array, int arrayIndex);
```
#### Parameters
<a name='OpenConstructionSet_Collections_OcsCollection_T__CopyTo(T___int)_array'></a>
`array` [T](CpJitxHTJ7jJqLOu30sQbg.md#OpenConstructionSet_Collections_OcsCollection_T__T 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The one-dimensional [System.Array](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array') that is the destination of the elements copied from [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'). The [System.Array](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array') must have zero-based indexing.
  
<a name='OpenConstructionSet_Collections_OcsCollection_T__CopyTo(T___int)_arrayIndex'></a>
`arrayIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The zero-based index in [array](vDEM74GZVFdz03itlaF4rg.md#OpenConstructionSet_Collections_OcsCollection_T__CopyTo(T___int)_array 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.CopyTo(T[], int).array') at which copying begins.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[array](vDEM74GZVFdz03itlaF4rg.md#OpenConstructionSet_Collections_OcsCollection_T__CopyTo(T___int)_array 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.CopyTo(T[], int).array') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null').
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
[arrayIndex](vDEM74GZVFdz03itlaF4rg.md#OpenConstructionSet_Collections_OcsCollection_T__CopyTo(T___int)_arrayIndex 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.CopyTo(T[], int).arrayIndex') is less than 0.
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
The number of elements in the source [System.Collections.Generic.ICollection&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1') is greater than the available space from [arrayIndex](vDEM74GZVFdz03itlaF4rg.md#OpenConstructionSet_Collections_OcsCollection_T__CopyTo(T___int)_arrayIndex 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.CopyTo(T[], int).arrayIndex') to the end of the destination [array](vDEM74GZVFdz03itlaF4rg.md#OpenConstructionSet_Collections_OcsCollection_T__CopyTo(T___int)_array 'OpenConstructionSet.Collections.OcsCollection&lt;T&gt;.CopyTo(T[], int).array').

Implements [CopyTo(T[], int)](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1.CopyTo#System_Collections_Generic_ICollection_1_CopyTo__0[],System_Int32_ 'System.Collections.Generic.ICollection`1.CopyTo(`0[],System.Int32)')  
