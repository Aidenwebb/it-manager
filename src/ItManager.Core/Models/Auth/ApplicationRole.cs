using Microsoft.AspNetCore.Identity;

namespace ItManager.Core.Models.Auth;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() : base()
    {
        
    }
    
    public ApplicationRole(string roleName) : base(roleName)
    {
        
    }

}