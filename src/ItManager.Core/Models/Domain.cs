namespace ItManager.Core.Models;

/// <summary>
/// Represents a single web domain that can have only one registrar.
/// </summary>
public class Domain
{
    /// <summary>
    /// The primary key of this domain in the database.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the domain.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Contains the registrar that manages this domain.
    /// </summary>
    public Registrar Registrar { get; set; } = null!;
}
