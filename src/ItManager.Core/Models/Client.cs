namespace ItManager.Core.Models;

/// <summary>
/// Represents a single client of the application.
/// </summary>
public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}