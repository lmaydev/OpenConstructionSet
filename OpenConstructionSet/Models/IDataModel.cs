using OpenConstructionSet.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Models;

/// <summary>
/// A data model to be consumed by the <see cref="OcsList{T}"/> class.
/// </summary>
public interface IDataModel
{
    /// <summary>
    /// The data model's unique identifier.
    /// </summary>
    string Key { get; }
}
