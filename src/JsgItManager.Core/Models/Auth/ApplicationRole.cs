using Microsoft.AspNetCore.Identity;

namespace JsgItManager.Core.Models.Auth;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() : base()
    {
        
    }
    
    public ApplicationRole(string roleName) : base(roleName)
    {
        
    }

}