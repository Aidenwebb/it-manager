using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItManager.Core.Models;

/// <summary>
/// Represents a single registrar. Each registrar can contain multiple domains.
/// </summary>
public class Registrar
{
    /// <summary>
    /// The primary key of this registrar in the database.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of this registrar.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets all domains that are encapsulated by this registrar.
    /// </summary>
    public List<Domain> Domains { get; set; } = new();
}
