#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context')
## ModReferenceCollection Class
Collection to manage [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference')s.  
```csharp
public class ModReferenceCollection : LMay.Collections.KeyedItemList<string, OpenConstructionSet.Mods.ModReference>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [LMay.Collections.KeyedCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedCollection-2 'LMay.Collections.KeyedCollection`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedCollection-2 'LMay.Collections.KeyedCollection`2')[ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedCollection-2 'LMay.Collections.KeyedCollection`2') &#129106; [LMay.Collections.KeyedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedList-2 'LMay.Collections.KeyedList`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedList-2 'LMay.Collections.KeyedList`2')[ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedList-2 'LMay.Collections.KeyedList`2') &#129106; [LMay.Collections.KeyedItemList&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedItemList-2 'LMay.Collections.KeyedItemList`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedItemList-2 'LMay.Collections.KeyedItemList`2')[ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedItemList-2 'LMay.Collections.KeyedItemList`2') &#129106; ModReferenceCollection  

| Methods | |
| :--- | :--- |
| [Add(IItem, int, int, int)](4uzJyB+u5qMHQzCDtdsyUA.md 'OpenConstructionSet.Mods.Context.ModReferenceCollection.Add(OpenConstructionSet.Data.IItem, int, int, int)') | Adds a new [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') to the collection with the provided values.<br/> |
| [Add(ModReference)](W+FjYIcANOn0PKgneQvClg.md 'OpenConstructionSet.Mods.Context.ModReferenceCollection.Add(OpenConstructionSet.Mods.ModReference)') | Adds the provided [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') to the collection.<br/> |
| [Add(string, int, int, int)](Y6EMupJvT18N2jJng+2gcw.md 'OpenConstructionSet.Mods.Context.ModReferenceCollection.Add(string, int, int, int)') | Adds a new [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') to the collection with the provided values.<br/> |
| [AddFrom(IReference)](ZHhYhOep8taqA7FHddfVUw.md 'OpenConstructionSet.Mods.Context.ModReferenceCollection.AddFrom(OpenConstructionSet.Data.IReference)') | Adds a new [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') based on the provided [IReference](vKi1zmew+odEqSm8IGr+UQ.md 'OpenConstructionSet.Data.IReference').<br/>If the [IReference](vKi1zmew+odEqSm8IGr+UQ.md 'OpenConstructionSet.Data.IReference') is a [ModReference](jj79_XszCKG+reGyMG6mKQ.md 'OpenConstructionSet.Mods.ModReference') it will be added without recreation.<br/> |
| [GetChanges(ModReferenceCollection)](gSPUkJzE4_7Do1r_ZJ2Qpw.md 'OpenConstructionSet.Mods.Context.ModReferenceCollection.GetChanges(OpenConstructionSet.Mods.Context.ModReferenceCollection)') | Compares this collection with another returning any changes.<br/> |
| [TryGetChanges(ModReferenceCollection, List&lt;Reference&gt;)](dlkWrlT0ym3dpWv1yToO7g.md 'OpenConstructionSet.Mods.Context.ModReferenceCollection.TryGetChanges(OpenConstructionSet.Mods.Context.ModReferenceCollection, System.Collections.Generic.List&lt;OpenConstructionSet.Data.Reference&gt;)') | Compares this collection with another returning any changes.<br/> |