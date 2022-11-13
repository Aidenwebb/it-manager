using Microsoft.AspNetCore.Identity;
namespace ItManager.Core.Models.Auth;

public class ApplicationUser: IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
}