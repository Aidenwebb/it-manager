using Microsoft.AspNetCore.Identity;
namespace JsgItManager.Core.Models.Auth;

public class ApplicationUser: IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}