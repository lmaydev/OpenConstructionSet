#### [OpenConstructionSet](index.md 'index')
### [OpenConstructionSet.Mods.Context](index.md#OpenConstructionSet_Mods_Context 'OpenConstructionSet.Mods.Context')
## ModItemCollection Class
Collection to manage [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem')s.  
```csharp
public class ModItemCollection : LMay.Collections.KeyedItemCollection<string, OpenConstructionSet.Mods.ModItem>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [LMay.Collections.KeyedCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedCollection-2 'LMay.Collections.KeyedCollection`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedCollection-2 'LMay.Collections.KeyedCollection`2')[ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedCollection-2 'LMay.Collections.KeyedCollection`2') &#129106; [LMay.Collections.KeyedItemCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedItemCollection-2 'LMay.Collections.KeyedItemCollection`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedItemCollection-2 'LMay.Collections.KeyedItemCollection`2')[ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/LMay.Collections.KeyedItemCollection-2 'LMay.Collections.KeyedItemCollection`2') &#129106; ModItemCollection  

| Methods | |
| :--- | :--- |
| [Add(ModItem)](pqBdn6qbxtgwym6+Gi+HNw.md 'OpenConstructionSet.Mods.Context.ModItemCollection.Add(OpenConstructionSet.Mods.ModItem)') | Adds the provided [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem') to the collection.<br/> |
| [AddFrom(IItem)](ZXywK2ALiQfp4CSOMkrX8A.md 'OpenConstructionSet.Mods.Context.ModItemCollection.AddFrom(OpenConstructionSet.Data.IItem)') | Adds a new [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem') based on the provided [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem').<br/>If the [IItem](1xw59+1PxAxgqAyD92DMNg.md 'OpenConstructionSet.Data.IItem') is a [ModItem](RZThR5Y52fbBYJ8EaGN2IQ.md 'OpenConstructionSet.Mods.ModItem') it will be added without recreation.<br/> |
| [GetChanges(IDictionary&lt;string,ModItem&gt;)](0XYgPDmt+1G8sXvCnqDG_w.md 'OpenConstructionSet.Mods.Context.ModItemCollection.GetChanges(System.Collections.Generic.IDictionary&lt;string,OpenConstructionSet.Mods.ModItem&gt;)') | Compares this collection with another returning any changes.<br/> |
