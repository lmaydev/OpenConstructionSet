#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Collections](index.md#OpenConstructionSet_Collections 'OpenConstructionSet.Collections')
## OcsList&lt;T&gt; Class
String keyed list of data models.  
```csharp
public class OcsList<T> : System.Collections.Generic.SortedList<string, T>
    where T : OpenConstructionSet.Models.IDataModel
```
#### Type parameters
<a name='OpenConstructionSet_Collections_OcsList_T__T'></a>
`T`  
The data model.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Collections.Generic.SortedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedList-2 'System.Collections.Generic.SortedList`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedList-2 'System.Collections.Generic.SortedList`2')[T](77BqslMvsRSH2CwSkDQQpg.md#OpenConstructionSet_Collections_OcsList_T__T 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedList-2 'System.Collections.Generic.SortedList`2') &#129106; OcsList&lt;T&gt;  

Derived  
&#8627; [DataReferenceCategory](Q3bgwvSqRWv7sT4x1Fv8Zw.md 'OpenConstructionSet.Models.DataReferenceCategory')  

| Constructors | |
| :--- | :--- |
| [OcsList()](JoN8RydtX4AMrr+FRgi4jw.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.OcsList()') | Creates an empty `OcsList` |
| [OcsList(IEnumerable&lt;T&gt;)](ZrZsLdk5qRlU5qzeOhitzA.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.OcsList(System.Collections.Generic.IEnumerable&lt;T&gt;)') | Creates a `OcsList` populated with the passed collection.<br/> |

| Properties | |
| :--- | :--- |
| [this[string]](BFc67SjI_C1cjQUW1ZTMig.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.this[string]') | Get an item from the collection by it's key.<br/> |

| Methods | |
| :--- | :--- |
| [Add(string, T)](HQXtvKeRtpiyxgZNrsSAzA.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.Add(string, T)') | Adds a new data model to the collection.<br/>Key is ignored and the data model's key will be used.<br/>Cannot use duplicate keys.<br/> |
| [Add(T)](4vzDLQe6+6qaaN9IrqaoDw.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.Add(T)') | Adds a new data model to the collection.<br/>Model's key must be unique.<br/> |
| [AddRange(IEnumerable&lt;T&gt;)](PPrui37cusP_3p3lEJameg.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.AddRange(System.Collections.Generic.IEnumerable&lt;T&gt;)') | Add's the provided data models to collection.<br/> |
| [Update(T)](OzLcDl0nFd8Fru4rLfq4oA.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.Update(T)') | Adds a data model to the collection.<br/>If the model's key is already used the value will be replaced.<br/> |
| [UpdateRange(IEnumerable&lt;T&gt;)](W4wuCgfDTEGv40dU3Yvmow.md 'OpenConstructionSet.Collections.OcsList&lt;T&gt;.UpdateRange(System.Collections.Generic.IEnumerable&lt;T&gt;)') | Adds a data model to the collection.<br/>If any of the models' keys is already used the value will be replaced.<br/> |
